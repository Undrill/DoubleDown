using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewControlsTest : MonoBehaviour {

    private void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        if(collision.gameObject.tag == "death")
        {
            Debug.Log("Death from obstacle");
        }
    }
}
