using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundInit : MonoBehaviour {

    public GameObject background;
    public GameObject emptyBackgrounds;
    public int numberOfBackgrounds = 0;
    private int Stage = 0;
    private float backgroundHeight;

	void Start ()
    {
        backgroundHeight = background.transform.localScale.y;
        

        for (int i = 0; i < numberOfBackgrounds; i++)
        {
            Instantiate(background, new Vector3(0, i*backgroundHeight,0), Quaternion.identity, emptyBackgrounds.transform);
            Stage++;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "background")
        {
            collision.transform.position = new Vector3(0, Stage * backgroundHeight, 0);
            Stage++;

        }
    }
}
