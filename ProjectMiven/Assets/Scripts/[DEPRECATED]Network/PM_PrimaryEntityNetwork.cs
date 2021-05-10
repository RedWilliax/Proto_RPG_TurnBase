using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PM_PrimaryEntityNetwork : MonoBehaviourPunCallbacks, IPunObservable
{
    protected PM_NetworkType networkType = PM_NetworkType.None;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        throw new System.NotImplementedException();
    }

    #region PrimaryRPC

    protected void InitialisingServer()
    {
        photonView.RPC("RPCInitialisingServer", RpcTarget.OthersBuffered);
    }

    protected void InitialisingPlayer()
    {

    }

    [PunRPC]
    void RPCInitialisingServer()
    {
        if (networkType != PM_NetworkType.Client) return;




    }


    #endregion


}
