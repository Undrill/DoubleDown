using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {

    public GameObject bluePlayer;
    public GameObject redPlayer;

    public float touchForce = 0.5f;
    public float carRotation = 0.4f;

    private void FixedUpdate()
    {
        bool playerInput = Input.GetButton("Fire1");
        if(GameObject.Find("BlueCharacter").GetComponent<CollisionCheck>().dead == false && GameObject.Find("RedCharacter").GetComponent<CollisionCheck>().dead == false)
        {
            if (playerInput)
            {
                bluePlayer.GetComponent<Rigidbody>().AddForce(new Vector3(-touchForce, 0.0f, 0.0f), ForceMode.VelocityChange);
                redPlayer.GetComponent<Rigidbody>().AddForce(new Vector3(touchForce, 0.0f, 0.0f), ForceMode.VelocityChange);
                bluePlayer.transform.Rotate(new Vector3(0, -carRotation, 0));
                redPlayer.transform.Rotate(new Vector3(0, carRotation, 0));
            }
            else
            {
                bluePlayer.GetComponent<Rigidbody>().AddForce(new Vector3(touchForce, 0.0f, 0.0f), ForceMode.VelocityChange);
                redPlayer.GetComponent<Rigidbody>().AddForce(new Vector3(-touchForce, 0.0f, 0.0f), ForceMode.VelocityChange);
                bluePlayer.transform.Rotate(new Vector3(0, carRotation, 0));
                redPlayer.transform.Rotate(new Vector3(0, -carRotation, 0));
            }
        }
        else
        {
            Debug.Log("Controls script says a player is dead");
        }
    }
}
