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
    string nameServ = "[MotherServer]";

    protected PM_NetworkType networkType = PM_NetworkType.None;

    protected List<RoomInfo> roomInfos;

    protected TypedLobby lobby = new TypedLobby("MivenLobby", LobbyType.Default);


    private void Start()
    {
        OnConnectToLobby();
    }
    void OnConnectToLobby()
    {
        PhotonNetwork.PhotonServerSettings.AppSettings.AppVersion = nameServ;
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

        Debug.Log(roomList.Count);

    }

    [PunRPC]
    public void PrimaryRPC(PM_NetworkType _byType, PM_NetworkType _forType,  Action _callBack)
    {
        _callBack.Invoke();
    }

    [PunRPC]
    public void PrimaryRPC<T1>(PM_NetworkType _byType, PM_NetworkType _forType, Action<T1> _callBack, T1 _t1)
    {
        _callBack.Invoke(_t1);
    }

}
