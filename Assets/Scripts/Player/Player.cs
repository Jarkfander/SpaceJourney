using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class Player : MonoBehaviour {

	[Header("Mouvement")]
	[SerializeField]
	private float[] velocities = {250};
	[SerializeField]
	private float acceleration = 0.05f;
	[Space]
	[SerializeField]
	private float pitchSensitivity = 30;
	[SerializeField]
	private float rollSensitivity = 30;
	[SerializeField]
	private float yawSensitivity = 30;

	[SerializeField]
	private float bankAngle = 30;

	[Space]
	[Header("Firing")]
	[SerializeField]
	private float fireRate = 2.0f;
	private float lastFireTime = 0.0f;
	[SerializeField]
	private AudioSource audioSourceLaser;
	[SerializeField]
	private Transform shotSpawn;
	[SerializeField]
	private GameObject laserObject;

	[Space]
	[Header("Engine effects")]
	[SerializeField]
	private Light[] reactors;
	[SerializeField]
	private AudioSource audioSourceEngine;
	[SerializeField]
	private float minReactorIntensity = 0.5f;
	[SerializeField]
	private float maxReactorIntensity = 3.0f;
	[SerializeField]
	private float minReactorRange = 100f;
	[SerializeField]
	private float maxReactorRange = 160f;
	[SerializeField]
	private float minEnginePitch = 0.2f;
	[SerializeField]
	private float maxEnginePitch = 1.2f;
	

	[Space]
	[Header("Life")]
	[SerializeField]
	private GameObject explosion;
	[SerializeField]
	private GameObject cam;

	private PlayerInput playerInput = null;
	private Transform childTransform = null;
	private int currentVelocity = 0;
	private float velocity = 0.0f;



	void Start () {
		playerInput = GetComponent<PlayerInput>();
		if(playerInput == null){
			//Debug.Log("Something went wrong: PlayerInput not found.");
			Destroy(this);
		}

		childTransform = transform.GetChild(0);
		if(childTransform == null){
			//Debug.Log("Something went wrong: could not find first child in player.");
			Destroy(this);
		}
	}
	
	void FixedUpdate () {
		
		transform.Rotate(
			playerInput.GetPitchValue()*Time.deltaTime*pitchSensitivity,
			playerInput.GetYawValue()*Time.deltaTime*yawSensitivity,
			playerInput.GetRollValue()*Time.deltaTime*rollSensitivity
		);
	
		float bankAmount = -Mathf.Lerp(-bankAngle, bankAngle, (playerInput.GetYawValue()+1)/2);

		childTransform.localRotation = Quaternion.Euler(0,0,bankAmount);

		//mouvement
		velocity = Mathf.Lerp(velocity, velocities[currentVelocity], acceleration);
		transform.Translate(transform.forward * velocity * Time.deltaTime, Space.World);
	}

	void Update(){
        if (childTransform == null)
        {
            Debug.Log("Something went wrong: could not find first child in player.");
            Destroy(this);
        }
        if (playerInput.GetAccelerate()){
			currentVelocity++;
		}

		if(playerInput.GetDescelerate()){
			currentVelocity--;
		}
		
		if(playerInput.IsFiring() && lastFireTime+(1/fireRate) < Time.time){
			Shoot();
			lastFireTime = Time.time;
		}

		currentVelocity = Mathf.Clamp(currentVelocity, 0, velocities.Length-1);
		SetEffectsOnSpeed();
	}

	void Shoot(){
		audioSourceLaser.Play();
		Instantiate(laserObject, shotSpawn.position, shotSpawn.rotation);
	}

	void SetEffectsOnSpeed(){
		float speedPercentage = Mathf.InverseLerp(velocities[0], velocities[velocities.Length-1], velocity);
		speedPercentage = Mathf.Clamp01(speedPercentage);
		foreach(Light l in reactors){
			l.intensity = Mathf.Lerp(minReactorIntensity, maxReactorIntensity, speedPercentage);
			l.range = Mathf.Lerp(minReactorRange, maxReactorRange, speedPercentage);
		}
		audioSourceEngine.pitch = Mathf.Lerp(minEnginePitch, maxEnginePitch, speedPercentage);
	}

	void OnCollisionEnter(Collision col){
		Instantiate(explosion, transform.position, transform.rotation);
		Universe.GetInstance().PlayerDied();
		GameObject freeCam = Instantiate(cam, cam.transform.position, cam.transform.rotation);
		Rigidbody rb = freeCam.AddComponent<Rigidbody>();
		rb.drag = 0;
		rb.useGravity = false;
		rb.velocity = Vector3.Normalize(cam.transform.position - transform.position)*2000;
		Destroy(this.gameObject);
	}
}
