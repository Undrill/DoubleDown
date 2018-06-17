using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour {

    public float forwardSpeed;

    void Update ()
    {
        if (GameObject.Find("BlueCharacter").GetComponent<CollisionCheck>().dead == false && GameObject.Find("RedCharacter").GetComponent<CollisionCheck>().dead == false)
        {
            this.transform.position = this.transform.position + new Vector3(0, forwardSpeed, 0);
        }
    }
}
