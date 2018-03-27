using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LauncherScreenController : MonoBehaviour {

	[SerializeField]
	private CanvasGroup disclaimerCanvasGroup;

	[SerializeField]
	private float FadeInFadeOutTime;

	[SerializeField]
	private float TimeToWait;

	void Start () {
		StartCoroutine(disclaimerRoutine());
	}

	private IEnumerator disclaimerRoutine(){
		
		//Text fade in
		disclaimerCanvasGroup.alpha = 0;
		while(disclaimerCanvasGroup.alpha < 1){
			disclaimerCanvasGroup.alpha += (1/FadeInFadeOutTime)*Time.deltaTime;
			yield return null;
		}
		disclaimerCanvasGroup.alpha = 1;

		//Pause avec le texte à l'écran
		yield return new WaitForSeconds(TimeToWait);

		//Test fade out
		while(disclaimerCanvasGroup.alpha > 0){
			disclaimerCanvasGroup.alpha -= (1/FadeInFadeOutTime)*Time.deltaTime;
			yield return null;
		}
		disclaimerCanvasGroup.alpha = 0;

		//Basculement vers le menu
		SceneManager.LoadScene("mainMenu");
	}
}
