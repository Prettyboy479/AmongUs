using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : Player
{
    public Transform cameraPosition;

    public override void Play()
    {
        transform.position = cameraPosition.position;
    }
}
