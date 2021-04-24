using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PM_PlayerNetworkManager : PM_PrimaryNetworkManager
{


    private void Awake()
    {
        networkType = PM_NetworkType.Client;
    }


    void JoinServer(string _nameServer)
    {
        // Sercutiry for full room

        PhotonNetwork.JoinRoom(_nameServer);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        //Receiver RPC Server + Instantiate Server + Call various command for player by Server



    }




    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(new Vector2(100, 100), new Vector2(150, 100)));

        for (int i = 0; i < roomInfos.Count; i++)
        {
            GUILayout.BeginHorizontal();

            GUILayout.Label(roomInfos[i].Name);

            GUILayout.Label($"{roomInfos[i].PlayerCount}");

            if (roomInfos[i].PlayerCount >= roomInfos[i].MaxPlayers)
            {
                GUILayout.Label("FULL");
                continue;
            }

            if(GUILayout.Button("Join"))
            {
                JoinServer(roomInfos[i].Name);
            }

            GUILayout.EndHorizontal();
        }

        GUILayout.EndArea();

    }

}
