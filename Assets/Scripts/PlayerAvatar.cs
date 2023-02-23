using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAvatar : MonoBehaviour
{
    //public GameObject player;
    
    public bool isNull = true;

    // Start is called before the first frame update
    void Start()
    {
        //player = this.GetComponent<GameObject>();
    }
    public void Fill()
    {
        isNull = false;
    }
    public void UnFill()
    {
        isNull = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
