using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Key : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float step = 0.1f;

        if (Input.GetKey(KeyCode.W)) {
			transform.Translate(0, step, 0);
		}
        if (Input.GetKey(KeyCode.A)) {
            transform.Translate(-step, 0, 0);
        }
        if (Input.GetKey(KeyCode.S)) {
            transform.Translate(0, -step, 0);
        }
        if (Input.GetKey(KeyCode.D)) {
            transform.Translate(step, 0, 0);
        }
        if (Input.GetKey(KeyCode.Q)) {
            transform.Translate(0, 0, -step);
        }
        if (Input.GetKey(KeyCode.E)) {
            transform.Translate(0, 0, step);
        }
    }
}
