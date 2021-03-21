using System.Collections;
using System.Collections.Generic;
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

    protected PM_NetworkType _networkType = PM_NetworkType.None;

    protected List<RoomInfo> roomInfos;

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
        PhotonNetwork.JoinLobby();
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        base.OnRoomListUpdate(roomList);

        roomInfos = roomList;
    }


}
