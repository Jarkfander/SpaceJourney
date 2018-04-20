using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAsteroid : MonoBehaviour
{
    public GameObject Shard;
    public GameObject Boum;
    public Vector3 location;
    public Vector3 velocity;

    private void OnTriggerEnter(Collider other)
    {
        location = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        GameObject Badoum = Instantiate(Boum, location, Quaternion.identity) as GameObject;

        location = new Vector3(transform.position.x,transform.position.y+900,transform.position.z);
        GameObject plop1 = Instantiate(Shard, location, Quaternion.identity) as GameObject;
        plop1.GetComponent<Rigidbody>().angularVelocity = new Vector3(100,100,100);

        location = new Vector3(transform.position.x+300, transform.position.y+300, transform.position.z+300);
        GameObject plop2 = Instantiate(Shard, location, Quaternion.identity) as GameObject;
        plop1.GetComponent<Rigidbody>().angularVelocity = new Vector3(100, 100, 100);

        location = new Vector3(transform.position.x + 300, transform.position.y + 300, transform.position.z-300);
        GameObject plop7 = Instantiate(Shard, location, Quaternion.identity) as GameObject;
        plop1.GetComponent<Rigidbody>().angularVelocity = new Vector3(100, 100, 100);

        location = new Vector3(transform.position.x-300, transform.position.y + 300, transform.position.z+300);
        GameObject plop5 = Instantiate(Shard, location, Quaternion.identity) as GameObject;
        plop1.GetComponent<Rigidbody>().angularVelocity = new Vector3(100, 100, 100);

        location = new Vector3(transform.position.x - 300, transform.position.y + 300, transform.position.z-300);
        GameObject plop8 = Instantiate(Shard, location, Quaternion.identity) as GameObject;
        plop1.GetComponent<Rigidbody>().angularVelocity = new Vector3(100, 100, 100);

        location = new Vector3(transform.position.x+300, transform.position.y-300, transform.position.z);
        GameObject plop3 = Instantiate(Shard, location, Quaternion.identity) as GameObject;
        plop1.GetComponent<Rigidbody>().angularVelocity = new Vector3(100, 100, 100);


        location = new Vector3(transform.position.x + 300, transform.position.y - 300, transform.position.z+300);
        GameObject plop9 = Instantiate(Shard, location, Quaternion.identity) as GameObject;
        plop1.GetComponent<Rigidbody>().angularVelocity = new Vector3(100, 100, 100);

        location = new Vector3(transform.position.x-300, transform.position.y - 300, transform.position.z);
        GameObject plop6 = Instantiate(Shard, location, Quaternion.identity) as GameObject;
        plop1.GetComponent<Rigidbody>().angularVelocity = new Vector3(100, 100, 100);

        location = new Vector3(transform.position.x - 300, transform.position.y - 300, transform.position.z-300);
        GameObject plop10    = Instantiate(Shard, location, Quaternion.identity) as GameObject;
        plop1.GetComponent<Rigidbody>().angularVelocity = new Vector3(100, 100, 100);

        location = new Vector3(transform.position.x,transform.position.y-900,transform.position.z);
        GameObject plop4 = Instantiate(Shard, location, Quaternion.identity) as GameObject;
        plop1.GetComponent<Rigidbody>().velocity = new Vector3(1,1,1);
        

        Destroy(gameObject);
        Debug.Log(message: "bit");
        //Destroy(obj: other.gameObject.GetComponent<Transform>().GetChild(0).gameObject);
    }
}
