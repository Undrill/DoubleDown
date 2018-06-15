using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraForward : MonoBehaviour {

    public float forwardSpeed = 0.3f;

    // Update is called once per frame
    void Update () {
        this.transform.position = this.transform.position + new Vector3(0, forwardSpeed, 0);
	}
}
