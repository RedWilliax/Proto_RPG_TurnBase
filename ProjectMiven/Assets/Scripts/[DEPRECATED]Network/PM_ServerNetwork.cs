using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PM_ServerNetwork : PM_PrimaryEntityNetwork
{
    Action OnInstantiateServer = null;

    private void Awake()
    {
        networkType = PM_NetworkType.Server;

        OnInstantiateServer += InstantiateServer;
    }

    private void Start()
    {
        InitialisingServer();
    }

    void InstantiateServer()
    {
        // Instantiate Other player 
        // Instantiate NPC
        // RPC Player
        // IA
        // Environnement

    }

    #region RPCs


    #endregion


}
