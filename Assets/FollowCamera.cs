using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // Gives the position of player
    public Transform target;

    // Initialize offset
    public Vector3 offset;

    private void FixedUpdate() 
    {
        // Adding the two vectors to the position of the camera
        transform.position = target.position+offset;
    
    }
}
