using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class RoomItem : MonoBehaviour
{
    public Text joinInput;
    CreateAndJoinRooms manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<CreateAndJoinRooms>();
    }
    public void SetRoomName(string _roomName)
    {
        joinInput.text = _roomName;
    }
    public void OnClickItem()
    {
        manager.JoinRoom(joinInput.text);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
