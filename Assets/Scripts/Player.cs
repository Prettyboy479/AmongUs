using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Player : MonoBehaviour
{
    //sets the view to a particular player
    PhotonView view;
    // Start is called before the first frame update
    void Start()
    {
        //connects the view to a component
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        //checks if the player is controlled by the local user
        if (view.IsMine)
        {
            //insert controls etc here
        }
    }
}
