using UnityEngine;
using System.Collections;
    
public class GameManager : MonoBehaviour
{

	//static reference to our gameManager instance, can be read by everyone with
	private static GameManager instance;

	void Awake()
	{
		/*
			This code is to set the game manager as a persistant singleton:
				- We check for the existence of a different gameManager
				- If there is, then we are a second gameManager and selfdestroy
				- We set ourselves in dontDestroyOnLoad, so we persist between scenes
		*/
		if(instance == null){
			instance = this;
		}else if(instance != this){
			Destroy(gameObject); 
		}
		DontDestroyOnLoad(gameObject);
		
		// INITIALISATION //
		/* This is where we initialise all the stuff we need */
	}
	
	public GameManager GetInstance(){
		return instance;
	}

	public void SetScene(){
		//TODO
	}
}