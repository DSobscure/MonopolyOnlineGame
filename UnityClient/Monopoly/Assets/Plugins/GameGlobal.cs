using UnityEngine;
using System.Collections;
using OnlineGameDataStructure;
using MonopolyGame;

public static class GameGlobal
{
    public static string ServerIP = "140.113.123.134";//"169.254.157.21";
    public static int ServerPort = 23*98;
    public static bool ConnectStatus = true;
    public static string version = "0.0.0";
    public static bool LoginStatus = false;
    public static Lobby lobby = null;
    public static Room room = null;
    public static string userName = "";
    public static Game playingGame = null;
}
