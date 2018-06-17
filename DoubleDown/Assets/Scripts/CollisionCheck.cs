using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{

    public bool dead = false;

    public void OnTriggerEnter(Collider playerCollision)
    {
        if (playerCollision.gameObject.tag == "obstacle")
        {
            dead = true;
            this.GetComponent<MeshRenderer>().enabled = false;
        }

        else if (playerCollision.gameObject.tag == "currency")
        {
            Debug.Log("Adding to Score");
        }
    }
}
