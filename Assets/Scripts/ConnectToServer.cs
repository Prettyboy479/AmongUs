using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        //connects to the photonnenetwork
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        //joins a lobby
        PhotonNetwork.JoinLobby();
       
    }
    public override void OnJoinedLobby()
    {
        //loads the lobby scene
        SceneManager.LoadScene("Lobby");
      
    }
    // Update is called once per frame
    void Update()
    {
    }
}
