using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PM_ServerNetworkManager : PM_PrimaryNetworkManager
{
    Action OnInstantiate = null;

    [SerializeField] string _nameServ = "Default_Name";
    [SerializeField] int _maxPlayer = 2;

    private void Awake()
    {
        networkType = PM_NetworkType.Server;

        OnInstantiate += InstantiateServer;
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        InitialisationServer();

    }

    void InitialisationServer()
    {
        //Various RPC boot Server

        //RPC Player

        photonView.RPC("PrimaryRPC", RpcTarget.OthersBuffered, networkType, PM_NetworkType.Client, OnInstantiate);

        //IA

        //Environnement

    }

    void InstantiateServer()
    {

    }

    void CreateServer(string _servName, int _maxPlayer)
    {
        RoomOptions _roomSettings = new RoomOptions()
        {
            MaxPlayers = (byte)_maxPlayer
        };

        PhotonNetwork.JoinOrCreateRoom(_servName, _roomSettings, lobby);
    }

    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
    }

    private void OnGUI()
    {

        GUILayout.BeginArea(new Rect(new Vector2(100, 100), new Vector2(150, 100)));

        if (GUILayout.Button("CreateRoom"))
        {
            CreateServer(_nameServ, _maxPlayer);
        }

       // GUILayout.Label($"Room List Count : {roomInfos.Count}");

        GUILayout.EndArea();
    }

}
