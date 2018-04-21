using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
public class DestroyShard : MonoBehaviour
{
    public GameObject Boum;
    public Vector3 location;
    private void OnCollisionEnter(Collision collision)
    {
        location = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        GameObject Badoum = Instantiate(Boum, location, Quaternion.identity) as GameObject;
        Destroy(gameObject);
    }
}
