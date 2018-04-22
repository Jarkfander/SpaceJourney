using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtmosphereScript : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if(other.CompareTag("Player")){
			Universe.GetInstance().SetScene("Namek", new Vector3 (0, 200, 0));
		}
	}
}
