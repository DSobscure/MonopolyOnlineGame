using UnityEngine;
using System.Collections;
using OnlineGameDataStructure;

public static class GameGlobal
{
    public static string ServerIP = "127.0.0.1";
    public static int ServerPort = 23*98;
    public static bool ConnectStatus = true;
    public static string version = "0.0.0";
    public static bool LoginStatus = false;
    public static Lobby lobby = null;
    public static Room room = null;
    public static string userName = "";
}
