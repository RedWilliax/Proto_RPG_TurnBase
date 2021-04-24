using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PM_ServerNetworkManager : PM_PrimaryNetworkManager
{
    Action OnInstantiate = null;

    [SerializeField] string nameServer = "Default_Name";
    [SerializeField] int maxPlayer = 2;

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
        RPC(RpcTarget.OthersBuffered, networkType, PM_NetworkType.Client, OnInstantiate);

        //RPC Player

        //IA

        //Environnement

    }

    void InstantiateServer()
    {
        // Instantiate Server Entity

        // Instantiate Other player 

        // Instantiate NPC

    }

    void CreateServer(string _servName, int _maxPlayer)
    {
        RoomOptions _roomSettings = new RoomOptions()
        {
            MaxPlayers = (byte)_maxPlayer

            // Custome properties O/C Server
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
            CreateServer(nameServer, maxPlayer);
        }

       // GUILayout.Label($"Room List Count : {roomInfos.Count}");

        GUILayout.EndArea();
    }

}
