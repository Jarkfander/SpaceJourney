using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAsteroid : MonoBehaviour
{   
    [SerializeField]
    private GameObject[] shards;
    [SerializeField]
    private GameObject explosion;
    [SerializeField]
    private int numberOfShards = 10;
    [SerializeField]
    private float shardsVelocity = 1000.0f;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Shot")){
            Instantiate(explosion, transform.position, Quaternion.identity);

            for(int i = 0; i < numberOfShards; i++){
                Vector3 direction = new Vector3(Random.Range(-1.0f,1.0f), Random.Range(-1.0f,1.0f), Random.Range(-1.0f,1.0f));
                direction = direction.normalized;
                GameObject shard = Instantiate(shards[Random.Range(0, shards.Length)], transform.position + direction*50, Quaternion.identity);
                shard.GetComponent<Rigidbody>().velocity = direction*shardsVelocity;
            }

            Destroy(gameObject);
        }
    }
}
