using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {

    public float forwardSpeed = 0.3f;
    private float widthBackground;
    private bool dead = false;
    public GameObject bluePlayer;
    public GameObject redPlayer;

    private float leftBorder;
    private float rightBorder;

    public float touchForce = 0.5f;
    public float carRotation = 0.4f;


    private void Start()
    {
        widthBackground = GameObject.Find("Background(Clone)").transform.localScale.x;
        leftBorder = -(widthBackground / 2) + bluePlayer.transform.localScale.x / 2;
        rightBorder = widthBackground / 2 - bluePlayer.transform.localScale.x / 2;
    }

    private void FixedUpdate()
    {
        bool playerInput = Input.GetButton("Fire1");

        if(!dead)
        {
            if (playerInput)
            {
                bluePlayer.GetComponent<Rigidbody>().AddForce(new Vector3(-touchForce, 0.0f, 0.0f), ForceMode.VelocityChange);
                bluePlayer.transform.Rotate(new Vector3(0, -carRotation, 0));
                redPlayer.transform.Rotate(new Vector3(0, carRotation, 0));
                redPlayer.GetComponent<Rigidbody>().AddForce(new Vector3(touchForce, 0.0f, 0.0f), ForceMode.VelocityChange);
            }
            else
            {
                bluePlayer.GetComponent<Rigidbody>().AddForce(new Vector3(touchForce, 0.0f, 0.0f), ForceMode.VelocityChange);
                redPlayer.GetComponent<Rigidbody>().AddForce(new Vector3(-touchForce, 0.0f, 0.0f), ForceMode.VelocityChange);
                bluePlayer.transform.Rotate(new Vector3(0, carRotation, 0));
                redPlayer.transform.Rotate(new Vector3(0, -carRotation, 0));
            }

            this.transform.position = this.transform.position + new Vector3(0, forwardSpeed, 0);
        }        

        if (bluePlayer.transform.position.x <= leftBorder || bluePlayer.transform.position.x >= rightBorder)
        {
            dead = true;
        }

        if (dead)
        {
            Debug.Log("Dead");
        }
    }
}
