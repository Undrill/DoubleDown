using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    public CollisionCheck otherPlayer;
    public bool dead = false;

    public void Start()
    {
        if (this.name == "RedCharacter")
        {
            otherPlayer = GameObject.Find("BlueCharacter").GetComponent<CollisionCheck>();
        }
        else
        {
            otherPlayer = GameObject.Find("RedCharacter").GetComponent<CollisionCheck>();
        }

    }

    public void Update()
    {
        if (otherPlayer.dead == true)
        {
            this.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    public void OnTriggerEnter(Collider playerCollision)
    {
        if (playerCollision.gameObject.tag == "obstacle")
        {
            dead = true;
            this.GetComponent<Rigidbody>().isKinematic = true;
        }

        else if (playerCollision.gameObject.tag == "currency")
        {
            Debug.Log("Adding to Score");
        }
    }
}
