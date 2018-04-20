using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class Player : MonoBehaviour {

	[SerializeField]
	private float[] velocities = {250};
	[SerializeField]
	private float pitchSensitivity = 30;
	[SerializeField]
	private float rollSensitivity = 30;
	[SerializeField]
	private float yawSensitivity = 30;

	[SerializeField]
	private float bankAngle = 30;

	private PlayerInput playerInput = null;
	private Transform childTransform = null;
	private int currentVelocity = 0;
	private float velocity;

	void Start () {
		playerInput = GetComponent<PlayerInput>();
		if(playerInput == null){
			//Debug.Log("Something went wrong: PlayerInput not found.");
			Destroy(this);
		}

		childTransform = transform.GetChild(0);
		if(childTransform == null){
			//Debug.Log("Something went wrong: could not find first child in player.");
			Destroy(this);
		}
	}
	
	void FixedUpdate () {
		
		transform.Rotate(
			playerInput.GetPitchValue()*Time.deltaTime*pitchSensitivity,
			playerInput.GetYawValue()*Time.deltaTime*yawSensitivity,
			playerInput.GetRollValue()*Time.deltaTime*rollSensitivity
		);
	
		float bankAmount = -Mathf.Lerp(-bankAngle, bankAngle, (playerInput.GetYawValue()+1)/2);

		childTransform.localRotation = Quaternion.Euler(0,0,bankAmount);

		//mouvement
		transform.Translate(transform.forward * velocities[currentVelocity] * Time.deltaTime, Space.World);
	}

	void Update(){
        if (childTransform == null)
        {
            Debug.Log("Something went wrong: could not find first child in player.");
            Destroy(this);
        }
        if (playerInput.GetAccelerate()){
			currentVelocity++;
		}

		if(playerInput.GetDescelerate()){
			currentVelocity--;
		}
		
		currentVelocity = Mathf.Clamp(currentVelocity, 0, velocities.Length-1);
	}
}
