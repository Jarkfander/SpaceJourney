using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

	[SerializeField]
	private float lifetime = 30.0f;

	[SerializeField]
	private float speed = 30.0f;

	// Use this for initialization
	void Start () {
		Destroy(this.gameObject, 30.0f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
	}

	void OnCollisionEnter(Collision collision){
		Destroy(this.gameObject);
	}
}
