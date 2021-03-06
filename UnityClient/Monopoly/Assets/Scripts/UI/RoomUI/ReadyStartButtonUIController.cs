﻿using UnityEngine;
using UnityEngine.UI;
using OnlineGameDataStructure;
using System.Linq;

public class ReadyStartButtonUIController : MonoBehaviour
{
    [SerializeField]
    private Button ReadyStartButton;

	void Start ()
    {
        PeerGlobal.PS.OnRoomUpdate += StartButtonCheck;
        if (GameGlobal.room.host.userName == GameGlobal.userName)
        {
            ReadyStartButton.GetComponentInChildren<Text>().text = "開始遊戲";
            ReadyStartButton.enabled = false;
        }
	}
    void OnDestroy()
    {
        PeerGlobal.PS.OnRoomUpdate -= StartButtonCheck;
    }

    internal void StartButtonCheck(Room room)
    {
        if (GameGlobal.room.host.userName == GameGlobal.userName)
        {
            if(room.users.Count > 1 && !room.users.Any(x=>x.Value.ready == false))
            {
                ReadyStartButton.enabled = true;
            }
            else
            {
                ReadyStartButton.enabled = false;
            }
        }
        else
        {
            if (room.users.ContainsKey(GameGlobal.userName))
            {
                if(room.users[GameGlobal.userName].ready)
                {
                    ReadyStartButton.GetComponentInChildren<Text>().text = "取消";
                }
                else
                {
                    ReadyStartButton.GetComponentInChildren<Text>().text = "準備";
                }
            }
        }
    }
}
