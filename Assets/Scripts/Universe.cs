using UnityEngine;
using System.Collections;
    
public class Universe : MonoBehaviour
{

	//static reference to our universe instance, can be read by everyone with
	private static Universe instance;

	void Awake()
	{
		/*
			This code is to set the game manager as a persistant singleton:
				- We check for the existence of a different universe
				- If there is, then we are a second universe and selfdestroy
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
	
	public Universe GetInstance(){
		return instance;
	}

	public void SetScene(){
		//TODO
	}
}