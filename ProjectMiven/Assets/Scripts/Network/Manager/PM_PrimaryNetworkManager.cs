using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public enum PM_NetworkType
{
    Server,
    Client,
    None
}

public class PM_PrimaryNetworkManager : MonoBehaviourPunCallbacks
{
    string namePrimaryServ = "[MotherServer]";

    protected List<RoomInfo> roomInfos = new List<RoomInfo>();

    protected TypedLobby lobby = new TypedLobby("MivenLobby", LobbyType.Default);


    private void Start()
    {
        Debug.Log("Primary Start");

        OnConnectToLobby();
    }
    void OnConnectToLobby()
    {
        PhotonNetwork.PhotonServerSettings.AppSettings.AppVersion = namePrimaryServ;
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        PhotonNetwork.JoinLobby(lobby);
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        base.OnRoomListUpdate(roomList);

        roomInfos = roomList;

        Debug.Log(roomList.Count);

    }
}
