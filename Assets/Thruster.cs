﻿using UnityEngine;
using System.Collections;

public class Thruster : MonoBehaviour {
	
	public Vector3 heading = new Vector3(0,0,0);
	public KeyCode key;
	public Rocket rocket;
	
	public InputInterface inputInterface;
	
	float force;
	public float maxForce = 0;
	public float minForce = 0;
	
	// Use this for initialization
	void Start () {
		heading.Normalize ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate () {
		force = inputInterface.accelerate * maxForce;
		
		if (rocket)
		{
			rocket.AddForceAtPosition(force * transform.forward, transform.position);
		}
	}
	
	void ApplyForce(Rigidbody body, float force_magnitude) {
		body.AddForceAtPosition (force*transform.forward, transform.position);
	}
}
