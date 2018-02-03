using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRandomRotation : MonoBehaviour {

	[Header("Rotation change random ranges")]
	[SerializeField]
	private Vector2 MinMaxValuesX;
	[SerializeField]
	private Vector2 MinMaxValuesY;
	[SerializeField]
	private Vector2 MinMaxValuesZ;

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
			targetRotation = Quaternion.Euler(
				transform.localRotation.eulerAngles.x + (Mathf.Sign(Random.Range(-1,1)) * Random.Range(MinMaxValuesX.x,MinMaxValuesX.y)),
				transform.localRotation.eulerAngles.y + (Mathf.Sign(Random.Range(-1,1)) * Random.Range(MinMaxValuesY.x,MinMaxValuesY.y)),
				transform.localRotation.eulerAngles.z + (Mathf.Sign(Random.Range(-1,1)) * Random.Range(MinMaxValuesZ.x,MinMaxValuesZ.y))
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
		if(MinMaxValuesX.x < 0){
			MinMaxValuesX.x = 0;
		}
		if(MinMaxValuesX.y < MinMaxValuesX.x){
			MinMaxValuesX.y = MinMaxValuesX.x;
		}
		
		if(MinMaxValuesY.x < 0){
			MinMaxValuesY.x = 0;
		}
		if(MinMaxValuesY.y < MinMaxValuesY.x){
			MinMaxValuesY.y = MinMaxValuesY.x;
		}

		if(MinMaxValuesZ.x < 0){
			MinMaxValuesZ.x = 0;
		}
		if(MinMaxValuesZ.y < MinMaxValuesZ.x){
			MinMaxValuesZ.y = MinMaxValuesZ.x;
		}

		easeAmount = Mathf.Clamp01(easeAmount);
	}
}
