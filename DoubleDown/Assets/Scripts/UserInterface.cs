using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserInterface : MonoBehaviour {


    private void OnGUI()
    {
        if (GameObject.Find("BlueCharacter").GetComponent<CollisionCheck>().dead == true || GameObject.Find("RedCharacter").GetComponent<CollisionCheck>().dead == true)
        {
            DisplayRestartButton();
        }
    }

    private void DisplayRestartButton()
    {
        Rect buttonRect = new Rect(Screen.width * 0.35f, Screen.height * 0.45f, Screen.width * 0.30f, Screen.height * 0.1f);

        if (GUI.Button(buttonRect, "Tap to restart!"))
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}