using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

	[SerializeField]
	private float rollGravity = 1.0f;
	[SerializeField]
	private float yawGravity = 1.0f;
	[SerializeField]
	private float pitchGravity = 1.0f;
	[SerializeField]
	private bool invertedVerticalControls = false;

	//Valeurs de roll
	private float rollValue = 0.0f;
	private float rollSignLastFrame = 0.0f;

	//Valeurs de yaw
	private float yawValue = 0.0f;
	private float yawSignLastFrame = 0.0f;

	//Valeurs de pitch
	private float pitchValue = 0.0f;
	private float pitchSignLastFrame = 0.0f;

	void Update () {
		/* ROLL */
		/*if((Input.GetAxisRaw("RollLeft") > 0.0f) ^ (Input.GetAxisRaw("RollRight") > 0.0f)){
			if(Input.GetAxisRaw("RollLeft") > 0.0f){
				rollValue += Time.deltaTime/rollGravity;
			} else {
				rollValue -= Time.deltaTime/rollGravity;
			}*/

		if(Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f){
			if(Input.GetAxis("Horizontal") < 0.0f){
				rollValue += Time.deltaTime/rollGravity;
			} else {
				rollValue -= Time.deltaTime/rollGravity;
			}
		} else {
			if(rollValue != 0.0f){
				
				rollValue += Time.deltaTime/rollGravity * Mathf.Sign(rollValue) * -1;

				if(rollSignLastFrame != Mathf.Sign(rollValue)){
					rollValue = 0.0f;
				}
			}
		}
		rollValue = Mathf.Clamp(rollValue, -1, 1);
		rollSignLastFrame = Mathf.Sign(rollValue);


		/* YAW */
		/*if(Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f){
			if(Input.GetAxis("Horizontal") < 0.0f){
				yawValue -= Time.deltaTime/yawGravity;
			} else {
				yawValue += Time.deltaTime/yawGravity;
			}*/
		if((Input.GetAxisRaw("RollLeft") > 0.0f) ^ (Input.GetAxisRaw("RollRight") > 0.0f)){
			if(Input.GetAxisRaw("RollLeft") > 0.0f){
				yawValue -= Time.deltaTime/yawGravity;
			} else {
				yawValue += Time.deltaTime/yawGravity;
			}
		} else {
			if(yawValue != 0.0f){
				
				Debug.Log(Mathf.Sign(yawValue) + "  " + yawSignLastFrame);
				yawValue += Time.deltaTime/yawGravity * Mathf.Sign(yawValue) * -1;

				if(yawSignLastFrame != Mathf.Sign(yawValue)){
					yawValue = 0.0f;
				}
			}
		}
		yawValue = Mathf.Clamp(yawValue, -1, 1);
		yawSignLastFrame = Mathf.Sign(yawValue);

		/* PITCH */
		if(Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f){
			if(Input.GetAxis("Vertical") > 0.0f){
				pitchValue += Time.deltaTime/pitchGravity * ((invertedVerticalControls)?-1:1);
			} else {
				pitchValue += Time.deltaTime/pitchGravity * ((invertedVerticalControls)?1:-1);
			}
		} else {
			if(pitchValue != 0.0f){

				pitchValue += Time.deltaTime/pitchGravity * Mathf.Sign(pitchValue) * -1;

				if(pitchSignLastFrame != Mathf.Sign(pitchValue)){
					pitchValue = 0.0f;
				}
			}
		}
		pitchValue = Mathf.Clamp(pitchValue, -1, 1);
		pitchSignLastFrame = Mathf.Sign(pitchValue);

	}

	public float GetRollValue(){
		return rollValue;
	}

	public float GetYawValue(){
		return yawValue;
	}

	public float GetPitchValue(){
		return pitchValue;
	}

	public float GetRollValueSquared(){
		return rollValue*Mathf.Abs(rollValue);
	}

	public float GetYawValueSquared(){
		return yawValue*Mathf.Abs(yawValue);
	}

	public float GetPitchValueSquared(){
		return pitchValue*Mathf.Abs(pitchValue);
	}
}
