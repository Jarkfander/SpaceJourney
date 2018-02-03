using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRandomRotation : MonoBehaviour {

	[Header("Rotation range")]
	[SerializeField]
	private Vector2 MinMaxValues;

	[Header("Rotation speed")]
	[SerializeField]
	private float DirectionChangeTimer = 5.0f;
	[SerializeField]
	private float easeAmount = 0.5f;

	private Quaternion targetRotation, startRotation;
	private float slerpPercentage;

	// Use this for initialization
	void Start () {
		slerpPercentage = 0.0f;
		targetRotation = Quaternion.identity;
		startRotation = transform.localRotation;
		StartCoroutine(changeTarget());
	}

	void Update(){
		slerpPercentage = slerpPercentage + Time.deltaTime/DirectionChangeTimer;
		transform.localRotation = Quaternion.Slerp(startRotation, targetRotation, Ease01(slerpPercentage, easeAmount));
	}
	
	IEnumerator changeTarget(){
		while(true){
			Debug.Log("Changed Direction");
			targetRotation = Quaternion.Euler(
				transform.localRotation.eulerAngles.x + Random.Range(MinMaxValues.x,MinMaxValues.y),
				transform.localRotation.eulerAngles.y + Random.Range(MinMaxValues.x,MinMaxValues.y),
				transform.localRotation.eulerAngles.z + Random.Range(MinMaxValues.x,MinMaxValues.y)
			);

			startRotation = transform.localRotation;
			slerpPercentage = 0.0f;
			yield return new WaitForSeconds(DirectionChangeTimer);
		}
	}

	private float Ease01(float x, float ease) {
		ease = Mathf.Clamp01(ease);
		x = Mathf.Clamp01(x);
		float a = ease + 1;
		return Mathf.Pow(x,a) / (Mathf.Pow(x,a) + Mathf.Pow(1-x,a));
	}

	void OnValidate(){
		if(MinMaxValues.x > 0){
			MinMaxValues.x = 0;
		}

		if(MinMaxValues.y < 0){
			MinMaxValues.y = 0;
		}

		easeAmount = Mathf.Clamp01(easeAmount);
	}
}
