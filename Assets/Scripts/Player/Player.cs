using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class Player : MonoBehaviour {

	[SerializeField]
	private float velocity = 250.0f;
	[SerializeField]
	private float pitchSensitivity = 30;
	[SerializeField]
	private float rollSensitivity = 30;
	[SerializeField]
	private float yawSensitivity = 30;

	private PlayerInput playerInput = null;
	private Transform childTransform = null;

	void Start () {
		playerInput = GetComponent<PlayerInput>();
		if(playerInput == null){
			Debug.Log("Something went wrong: PlayerInput not found.");
			Destroy(this);
		}

		childTransform = transform.GetChild(0);
		if(childTransform == null){
			Debug.Log("Something went wrong: could not find first child in player.");
			Destroy(this);
		}
	}
	
	void FixedUpdate () {
		
		transform.Rotate(
			playerInput.GetPitchValueSquared()*Time.deltaTime*pitchSensitivity,
			playerInput.GetYawValueSquared()*Time.deltaTime*yawSensitivity,
			playerInput.GetRollValueSquared()*Time.deltaTime*rollSensitivity
		);


		transform.Translate(transform.forward * velocity * Time.deltaTime, Space.World);
	}
}
