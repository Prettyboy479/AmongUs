using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ConnectToServer : MonoBehaviourPunCallbacks
{

    public GameObject button;
    public InputField usernameInput;
    public Text buttonText;
    // Start is called before the first frame update
    void Start()
    {
       
        button.SetActive(true);
        //connects to the photonnenetwork
    }

    public override void OnConnectedToMaster()
    {
        //joins a lobby
        PhotonNetwork.JoinLobby();
       
    }
    public void Ready()
    {
        if (usernameInput.text.Length >= 1)
        {
            PhotonNetwork.NickName = usernameInput.text;
            buttonText.text = "Connecting...";
            PhotonNetwork.ConnectUsingSettings();
        }
        
        
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
