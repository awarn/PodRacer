using UnityEngine;
using System.Collections;

public class FalconInputInterface : InputInterface {

	public int falconNum;
	Vector3 tipPosition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (FalconUnity.getTipPosition (falconNum, out tipPosition)) {
			accelerate = Mathf.Clamp(((tipPosition.z - 0.035f) * -1 * 10), 0, 1);
		} else {
			accelerate = 0;
		}
	}

}
