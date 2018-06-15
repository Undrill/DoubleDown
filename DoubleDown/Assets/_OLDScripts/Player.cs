using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Vector3 stageDimensions;
    private bool restart = false;

    private void Start()
    {
        

    }

    private void Update()
    {
        stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        Debug.Log("Stage Dimension X is: " + stageDimensions.x);
        Debug.Log("This Transform position X is : " + this.transform.position);

        if (this.transform.position.x >= stageDimensions.x - this.GetComponent<BoxCollider>().size.x/2)
        {
            restart = true;
        }
    }

    private void OnGUI()
    {
        DisplayRestartButton();
    }

    void DisplayRestartButton()
    {
        if (restart == true)
        {
            Rect buttonRect = new Rect(Screen.width * 0.35f, Screen.height * 0.45f, Screen.width * 0.30f, Screen.height * 0.1f);

            Camera.main.transform.position = new Vector3(0, this.transform.position.y + 3, -10);
            if (GUI.Button(buttonRect, "Tap to restart!"))
            {
                Application.LoadLevel(Application.loadedLevelName);
            }
        }
    }
}
