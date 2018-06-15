using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    public GameObject bluePlayer;
    public GameObject redPlayer;
    public float SpeedHeight = 1.0f;
    public float touchForce = 0.5f;

    private bool dead = false;
    private Vector3 stageDimensions;


    void Start()
    {
        stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
    }

    // Use this for Phyiscs
    void FixedUpdate()
    {
        bool PlayerInput = Input.GetButton("Fire1");

        if (!dead)
        {
             if (PlayerInput)
            {
                bluePlayer.GetComponent<Rigidbody>().AddForce(new Vector3(-touchForce, 0.0f, 0.0f), ForceMode.VelocityChange);
                redPlayer.GetComponent<Rigidbody>().AddForce(new Vector3(touchForce, 0.0f, 0.0f), ForceMode.VelocityChange);

                //bluePlayer.position = bluePlayer.position + new Vector3(SpeedWidth, 0, 0) * Time.deltaTime;
                //redPlayer.position = redPlayer.position + new Vector3(-SpeedWidth, 0, 0) * Time.deltaTime;
            }

            else
            {
                bluePlayer.GetComponent<Rigidbody>().AddForce(new Vector3(touchForce, 0.0f, 0.0f), ForceMode.VelocityChange);
                redPlayer.GetComponent<Rigidbody>().AddForce(new Vector3(-touchForce, 0.0f, 0.0f), ForceMode.VelocityChange);

                //bluePlayer.position = bluePlayer.position + new Vector3(-SpeedWidth, 0, 0) * Time.deltaTime;
                //redPlayer.position = redPlayer.position + new Vector3(SpeedWidth, 0, 0) * Time.deltaTime;
            }

            this.transform.position = this.transform.position + new Vector3(0, SpeedHeight, 0) * Time.deltaTime;
        }

        if (redPlayer.transform.position.x >= stageDimensions.x - redPlayer.GetComponent<BoxCollider>().size.x / 2 || redPlayer.transform.position.x <= -stageDimensions.x + redPlayer.GetComponent<BoxCollider>().size.x / 2)
        {
            dead = true;
        }
    }

    private void OnGUI()
    {
        DisplayRestartButton();
    }

    void DisplayRestartButton()
    {
        if (dead)
        {
            Rect buttonRect = new Rect(Screen.width * 0.35f, Screen.height * 0.45f, Screen.width * 0.30f, Screen.height * 0.1f);

            Camera.main.transform.position = new Vector3(0, this.transform.position.y, -10);
            if (GUI.Button(buttonRect, "Tap to restart!"))
            {
                Application.LoadLevel(Application.loadedLevelName);
            }
        }
    }
}
