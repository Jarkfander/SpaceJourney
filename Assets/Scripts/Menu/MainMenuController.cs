using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour {

	void Update () {
		if (Input.anyKey && !Input.GetKey("joystick button 7") && !Input.GetKey(KeyCode.N) && !Input.GetKey("joystick button 6") && !Input.GetKey(KeyCode.B)){
			Universe.GetInstance().SetScene("Game", new Vector3(0, 0, 0));
		}
	}
}
