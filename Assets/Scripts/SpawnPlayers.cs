using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;
    public float minX;
    public float maxX;
    public float maxY;
    public float minY;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
