using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmoothBlink : MonoBehaviour {

	[SerializeField]
	private float TimeToFadeInOut;

	private Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
		StartCoroutine(Blink());
	}

	private IEnumerator Blink(){
		float alpha = 0;
		while(true){
			text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
			while(alpha < 1){
				alpha += Time.deltaTime*(1/TimeToFadeInOut);
				Mathf.Clamp01(alpha);
				text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
				yield return null;
			}

			while(alpha > 0){
				alpha -= Time.deltaTime*(1/TimeToFadeInOut);
				Mathf.Clamp01(alpha);
				text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
				yield return null;
			}
		}
	}
}
