using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    //accesses the input you put in to create room
    public InputField createInput;
    //access the input you put in to join room
    public InputField joinInput;
    
    public GameObject lobbyPanel;
    public GameObject roomPanel;
    public Text roomname;
    public RoomItem roomItemPrefab;
    List<RoomItem> roomItemsList = new List<RoomItem>();
    public Transform contentObject;
    public float timeBetweenUpdate = 1.5f;
    float nextUpdateTime;

    public void CreateRoom()
    {
        if (createInput.text.Length >= 1)
        {
        PhotonNetwork.CreateRoom(createInput.text, new RoomOptions() { MaxPlayers = 4 });

        }
        //creates a room with the createinput text attached
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        if (Time.time >= nextUpdateTime)
        {

            UpdateRoomList(roomList);
            nextUpdateTime = Time.time + timeBetweenUpdate;
        }
    }
    public void JoinRoom(string _joinInput)
    {
        if (joinInput.text.Length >= 1)
        {

            //joins a room that matches the input you put in
            PhotonNetwork.JoinRoom(_joinInput);
        }
    }
    public void OnClickLeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }
    public override void OnLeftRoom()
    {
        roomPanel.SetActive(false);
        lobbyPanel.SetActive(true);

    }
    void UpdateRoomList(List<RoomInfo> list)
    {
        foreach (RoomItem item in roomItemsList)
        {
            Destroy(item.gameObject);
        }
        roomItemsList.Clear();
        foreach (RoomInfo room in list)
        {
            RoomItem newRoom = Instantiate(roomItemPrefab, contentObject);
            newRoom.SetRoomName(room.Name);
            roomItemsList.Add(newRoom);
        }

    }
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedRoom()
    {
        lobbyPanel.SetActive(false); 
        roomPanel.SetActive(true);
        roomname.text = "Room: " + PhotonNetwork.CurrentRoom.Name;
        //load a multiplayer level
        //PhotonNetwork.LoadLevel("Game");
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
