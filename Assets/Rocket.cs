using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
            
	}

	void FixedUpdate () {

	}

    public void AddForceAtPosition(Vector3 force, Vector3 position)
    {
        rigidbody.AddForceAtPosition(force, position);
    }
}
