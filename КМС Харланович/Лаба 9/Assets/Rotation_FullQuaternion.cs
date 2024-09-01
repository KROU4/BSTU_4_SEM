using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_FullQuaternion : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation *= Quaternion.AngleAxis(0.5f, new Vector3(0.5f, 1, 0.3f));
	}
}
