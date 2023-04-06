using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RespawnHandler : MonoBehaviourPun  
{
    public Transform teamAposition;
    public Transform teamBposition;
    public string teamName = "Blue";//Blue or Red team
    public float health = 0f;

    // void OnPhotonPlayerConnected(PhotonPla)
    void Update()
    {
        if (health <= 0)
        {
            string[] playerData = new string[2];
            playerData[0] = PhotonNetwork.LocalPlayer.UserId;
            playerData[1] = teamName;
            health = 100;

            photonView.RPC("Respawn", RpcTarget.All, playerData);
        }
    }

    [PunRPC]
    void Respawn(string[] playerData)
    {
        StartCoroutine(DelayedRespawn(playerData));
    }

    IEnumerator DelayedRespawn(string[] playerData)
    {
        yield return new WaitForSeconds(3f);
        foreach (var player in PhotonNetwork.PlayerList)
        {
            if (player.UserId != playerData[0]) continue;

            if (playerData[1].Equals("Blue"))
            {
                PlayerHandler.players[player.UserId].transform.position = teamAposition.position;

            }else{
                PlayerHandler.players[player.UserId].transform.position = teamBposition.position;
            }

        }
    }
}
