using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    //accesses the input you put in to create room
    public InputField createInput;
    //access the input you put in to join room
    public InputField joinInput;
   public void CreateRoom()
    {
        //creates a room with the createinput text attached
        PhotonNetwork.CreateRoom(createInput.text);
    }
    public void JoinRoom()
    {
        //joins a room that matches the input you put in
        PhotonNetwork.JoinRoom(joinInput.text);
    }
    public override void OnJoinedRoom()
    {
        //load a multiplayer level
        PhotonNetwork.LoadLevel("Game");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
