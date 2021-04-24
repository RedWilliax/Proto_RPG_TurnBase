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

    protected PM_NetworkType networkType = PM_NetworkType.None;

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

    #region RPCs

    public void RPC(RpcTarget _target, PM_NetworkType _byType, PM_NetworkType _forType, Action _callBack)
    {
        photonView.RPC("PrimaryRPC", _target, _byType, _forType, _callBack);
    }

    public void RPC<T1>(RpcTarget _target, PM_NetworkType _byType, PM_NetworkType _forType, Action<T1> _callBack, T1 _t1)
    {
        photonView.RPC("PrimaryRPC", _target, _byType, _forType, _callBack, _t1);
    }

    #endregion


    #region PrimaryRPC

    [PunRPC]
    void PrimaryRPC(PM_NetworkType _byType, PM_NetworkType _forType, Action _callBack)
    {
        if (_forType != networkType) return;

        Debug.Log("PrimaryRPC NO params");
        _callBack.Invoke();
    }

    [PunRPC]
    void PrimaryRPC<T1>(PM_NetworkType _byType, PM_NetworkType _forType, Action<T1> _callBack, T1 _t1)
    {
        if (_forType != networkType) return;

        Debug.Log("PrimaryRPC ONE params");
        _callBack.Invoke(_t1);
    }

    #endregion

}
