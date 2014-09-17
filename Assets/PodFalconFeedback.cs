using UnityEngine;
using System.Collections;

public class PodFalconFeedback : MonoBehaviour {
	
	public Vector3 vibration;

	Vector3 lastVelocity = Vector3.zero;
	public Vector3 currentVelocity;
	Vector3 acceleration;
	public Vector3 gForce;
	
	// Use this for initialization
	void Start () {
		lastVelocity = rigidbody.velocity;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		vibration = Random.insideUnitSphere;
		currentVelocity = rigidbody.velocity;


		acceleration = currentVelocity - lastVelocity / (Time.deltaTime);
		gForce = acceleration / Physics.gravity.magnitude;

		Debug.DrawRay (rigidbody.position, gForce);

		//FalconUnity.setForceField (0, vibration);

		lastVelocity = currentVelocity;
	}
}
