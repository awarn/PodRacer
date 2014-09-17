using UnityEngine;
using System.Collections;

public class KeyboardInputInterface : InputInterface {

	public KeyCode acceleration;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(acceleration)) {
			accelerate = 0.95f;
		} else {
			accelerate = 0;
		}
		accelerate = Mathf.Clamp (accelerate, 0, 1);
	}

}
