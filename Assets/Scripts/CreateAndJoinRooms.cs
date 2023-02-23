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
    public GameObject play;
    public Transform avatar;
    public GameObject player;
    public GameObject lobbyPanel;
    public GameObject roomPanel;
    public Image image;
    public Text roomname;
    public RoomItem roomItemPrefab;
    public List<RoomItem> roomItemsList = new List<RoomItem>();
    public List<PlayerAvatar> playerList = new List<PlayerAvatar>(12);
    public List<GameObject> playerGameList = new List<GameObject>(12);
    public List<Image> playerImageList = new List<Image>(12);
    public Transform contentObject;
    public float timeBetweenUpdate = 1.5f;
    float nextUpdateTime;
    //public playerItem player;

    public void CreateRoom()
    {
        if (createInput.text.Length >= 1)
        {
        PhotonNetwork.CreateRoom(createInput.text, new RoomOptions() { MaxPlayers = 12 });
            //playerList.Count = 12;
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
        Removeplayers(player);

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
    public void ReadyUp()
    {

        //load a multiplayer level
        PhotonNetwork.LoadLevel("Game");
    }
    public override void OnJoinedRoom()
    {
        
        lobbyPanel.SetActive(false); 
        roomPanel.SetActive(true);
        roomname.text = "Room: " + PhotonNetwork.CurrentRoom.Name;
        //player = Instantiate(play);
        Fillplayers(play);
    }
    public void Fillplayers(GameObject go)
    {
        for (int i = 0; i < playerGameList.Count; i++)
        {
            if (playerList[i].isNull == true)
            {
                avatar = playerGameList[i].GetComponent<Transform>();
                Debug.Log($"{go.transform.position}, {playerGameList[i].transform.position}");
                player = Instantiate(go,
                                     avatar.position,
                                     Quaternion.identity,
                                     avatar);
                                     //playerList[i].transform);
               
                Debug.Log($"{go.transform.position}");
                playerList[i].Fill();
                image = playerImageList[i].GetComponent<Image>();
                image.color = (new Color (255,255,255,0 ));
                //playerList[i].SetActive(false);
                break;
            }
        }
    }
    public void Removeplayers(GameObject go)
    {
        for (int i = 0; i < playerGameList.Count; i++)
        {
            if (playerGameList[i].transform.position == go.transform.position)
            {
                //playerList[i].Unfill();
                for (int j = i; j < playerGameList.Count - 1; j++)
                {
                    playerList[j] = playerList[j + 1];
                }
                break;
            }
        }
       playerList[playerList.Count].UnFill();
        Destroy(go);
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
