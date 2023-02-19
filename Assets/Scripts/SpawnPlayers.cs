using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class SpawnPlayers : MonoBehaviour
{
    //set playerprefab
    public GameObject playerPrefab;
    public GameObject cameraPrefab;
    //this four set the bounds in terms of where the player can spawn
    public float minX;
    public float maxX;
    public float maxY;
    public float minY;
    // Start is called before the first frame update
    void Start()
    {
        //gets a random point within the bounds set
        Vector2 randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        //spawns a player character at the random position
        //PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);
        PhotonNetwork.Instantiate(cameraPrefab.name, randomPosition, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
