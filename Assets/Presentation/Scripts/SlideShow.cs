using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlideShow : MonoBehaviour {

	[SerializeField]
	private Transform[] slides;
	[SerializeField]
	private float transitionDuration;
	[SerializeField]
	private string nextScene;
	
	private int currentSlide = 0;

	private Vector3 posStart;
	private Quaternion rotStart;

	private Vector3 posTarget;
	private Quaternion rotTarget;

	private float transitionPercentage;

	void Start(){
		posStart = transform.position;
		posTarget  = transform.position;
		rotStart = transform.rotation;
		rotTarget = transform.rotation;
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.V)){
			SceneManager.LoadScene(nextScene);
		}

		if(Input.GetButtonDown("Submit")){
			currentSlide++;
			currentSlide = Mathf.Clamp(currentSlide, 0, slides.Length-1);
			posStart = transform.position;
			posTarget = slides[currentSlide].position;
			rotStart = transform.rotation;
			rotTarget = slides[currentSlide].rotation;
			transitionPercentage = 0;

			Debug.Log("START transitionPercentage = " + transitionPercentage);
		}
		

		if(Input.GetButtonDown("Cancel")){
			currentSlide--;
			currentSlide = Mathf.Clamp(currentSlide, 0, slides.Length-1);
			posStart = transform.position;
			posTarget = slides[currentSlide].position;
			rotStart = transform.rotation;
			rotTarget = slides[currentSlide].rotation;
			transitionPercentage = 0;
		}

		if(transitionPercentage < 1){
			transitionPercentage += Time.deltaTime/transitionDuration;
		}

		transform.position = Vector3.Lerp(posStart, posTarget, transitionPercentage);
		transform.rotation = Quaternion.Lerp(rotStart, rotTarget, transitionPercentage);
	}
}
