using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReticleController : MonoBehaviour {

	[SerializeField]
	private Camera cam;

	[SerializeField]
	private LayerMask layerMask;
	// Update is called once per frame
	
	[SerializeField]
	private Image reticleSprite;

	[SerializeField]
	private float range = 10000.0f;

	void Update () {
		RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, range, layerMask))
        {
            Vector3 screenPosition = cam.WorldToScreenPoint(hit.point);
			reticleSprite.color = Color.cyan;
			reticleSprite.rectTransform.localPosition = new Vector3(screenPosition.x - Screen.width/2, screenPosition.y - Screen.height/2, 0.0f);	
        }
        else
        {
			Vector3 screenPosition = cam.WorldToScreenPoint(transform.position + (transform.forward*range));
			reticleSprite.color = Color.white;
			reticleSprite.rectTransform.localPosition = new Vector3(screenPosition.x - Screen.width/2, screenPosition.y - Screen.height/2, 0.0f);	
        }
	}
}
