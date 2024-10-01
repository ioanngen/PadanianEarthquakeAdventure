using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerController : MonoBehaviour
{
    //Serialized it so we can drag and drop the transform of the player object in the Unity Editor, when it starts it will
    //Be automatically initialized with the player transform.
    [SerializeField] Transform player;

    void Update()
    {
        transform.position = new Vector3(player.position.x,player.position.y,transform.position.z); //the default transform of the camera object
    }
}
