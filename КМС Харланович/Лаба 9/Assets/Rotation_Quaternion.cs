using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_Quaternion : MonoBehaviour {
	Quaternion _originalQuaternion;
	float _angle = 1;

	// Use this for initialization
	void Start () {
		_originalQuaternion = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation *= Quaternion.AngleAxis(_angle, Vector3.right);
        transform.rotation *= Quaternion.AngleAxis(_angle, Vector3.forward);
    }
}
