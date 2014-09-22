using UnityEngine;
using System.Collections;

public class Thruster : MonoBehaviour {

	public Rocket rocket;
	
	public InputInterface inputInterface;
	
	float force;
	public float maxForce = 0;
	public float minForce = 0;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate () {
		force = inputInterface.accelerate * maxForce;

		if (rocket.EnginesOn == true) {
			rocket.rigidbody.AddForceAtPosition(force * transform.forward, transform.position);
		}
	}
}
