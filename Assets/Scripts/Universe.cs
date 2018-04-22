using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
    
public class Universe : MonoBehaviour
{

	//static reference to our universe instance, can be read by everyone with
	private static Universe universeInstance;
	public Vector3 playerStartPosition;
	
	[SerializeField]
	private string[] sceneOrder;
	private int currentScene = 0;

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

	void Update(){
		if(Input.GetKey("joystick button 7") || Input.GetKey(KeyCode.N)){
			SceneManager.LoadScene(sceneOrder[Mathf.Clamp(currentScene+1, 0, sceneOrder.Length-1)]);
			currentScene++;
			currentScene = Mathf.Clamp(currentScene, 0, sceneOrder.Length);
		}
		if(Input.GetKey("joystick button 6") || Input.GetKey(KeyCode.B)){
			SceneManager.LoadScene(sceneOrder[Mathf.Clamp(currentScene-1, 0, sceneOrder.Length-1)]);
			currentScene--;
			currentScene = Mathf.Clamp(currentScene, 0, sceneOrder.Length);
		}
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

	public void SetScene(string sceneName, Vector3 playerPosition){
		SceneManager.LoadScene(sceneName);
		playerStartPosition = playerPosition;
	}
}