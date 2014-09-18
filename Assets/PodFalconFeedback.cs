using UnityEngine;
using System.Collections;

public class PodFalconFeedback : MonoBehaviour {

	// Random vibrations for engine running feel.
	Vector3 vibration;
	// Velocity last fixedupdate.
	Vector3 lastVelocity = Vector3.zero;
	// Velocity this fixedupdate.
	Vector3 currentVelocity;
	// Global acceleration.
	Vector3 acceleration;
	// Local G (acceleration/gravity in local space).
	Vector3 gForce;
	// Force to send to the Falcon.
	public Vector3 totalForce;
	
	// Use this for initialization
	void Start () {
		lastVelocity = rigidbody.velocity;
	}


	void FixedUpdate () {

		// Random vibrations for engine running feel.
		vibration = Random.insideUnitSphere;

		// Global velocity & acceleration.
		currentVelocity = rigidbody.velocity;
		acceleration = currentVelocity - lastVelocity / (Time.deltaTime);
		Debug.DrawRay (rigidbody.position, acceleration / 10);
		// Local gforce.
		gForce = transform.InverseTransformDirection( acceleration / Physics.gravity.magnitude );
		// Nullify g along z to allow braking and accelerating.
		gForce.z = 0;


		//Vector3 right = transform.TransformPoint (Vector3.right);
		//Debug.DrawLine (transform.TransformPoint(new Vector3(0.2f, 0.2f, 0.2f)) , transform.position + transform.up * 2 , Color.cyan);
		//Debug.DrawLine (transform.position, transform.position + Vector3.up * 2 , Color.magenta);


		// Sum and finalize forces before sending to Falcon.
		totalForce = -1 * gForce * 0.03f + vibration;
		// Add force to the Falcons.
		FalconUnity.setForceField (0, totalForce);
		//FalconUnity.setForceField (1, totalForce);

		// Prepare for next fixedupdate.
		lastVelocity = currentVelocity;
	}
}
