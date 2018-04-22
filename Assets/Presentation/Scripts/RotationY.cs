using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationY : MonoBehaviour {

	[SerializeField]
	private float speed = 0;

	void Update () {
		transform.Rotate(0, speed*Time.deltaTime, 0);
	}
}
