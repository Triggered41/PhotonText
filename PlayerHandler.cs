using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerHandler : MonoBehaviourPunCallbacks
{
    public Transform teamAposition;
    public Transform teamBposition;

    //Keep reference to all the players and their gameobjects
    // in userId: gameobject reference form
    public static Dictionary<string, GameObject> players = new Dictionary<string, GameObject>();
    public GameObject playerPrefab;//Player Gameobject Prefab

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        players.Add(newPlayer.UserId, Instantiate(playerPrefab, teamAposition.position, Quaternion.identity));
    }

}
