using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SCRIPTALACON : MonoBehaviour {

	void Update () {
		if(Input.GetKeyDown("joystick button 7")){
			SceneManager.LoadScene("Pres1");
		}
	}
}
