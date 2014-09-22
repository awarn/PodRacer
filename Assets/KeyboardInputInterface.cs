using UnityEngine;
using System.Collections;

public class KeyboardInputInterface : InputInterface {

	public KeyCode accButton;
	public KeyCode onButton;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(accButton)) {
			accelerate = 0.95f;
		} else {
			accelerate = 0;
		}
		accelerate = Mathf.Clamp (accelerate, 0, 0.95f);

		if (Input.GetKeyDown(onButton)) {
			enginesOn = !enginesOn;
		}
	}

}
