using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
    
public class Universe : MonoBehaviour
{

	//static reference to our universe instance, can be read by everyone with
	private static Universe universeInstance;

	void Awake()
	{
		/*
			This code is to set the game manager as a persistant singleton:
				- We check for the existence of a different universe
				- If there is, then we are a second universe and selfdestroy
				- We set ourselves in dontDestroyOnLoad, so we persist between scenes
		*/
		if(universeInstance == null){
			universeInstance = this;
		}else if(universeInstance != this){
			Destroy(gameObject); 
		}
		DontDestroyOnLoad(gameObject);
	}
	
	public static Universe GetInstance(){
		return universeInstance;
	}

	public void PlayerDied(){
		StartCoroutine(PlayerDeathSequence());
	}

	IEnumerator PlayerDeathSequence(){
		yield return new WaitForSeconds(5.0f);
		SceneManager.LoadScene("mainMenu");
	}
}