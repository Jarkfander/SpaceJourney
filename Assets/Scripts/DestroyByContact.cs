using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        Debug.Log(message: "anything");
        //Destroy(obj: other.gameObject.GetComponent<Transform>().GetChild(0).gameObject);
    }
}
