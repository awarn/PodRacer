using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour {

	public InputInterface inputInterface;

	private bool enginesOn;
	public bool EnginesOn { 
		get { return enginesOn; }
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		enginesOn = inputInterface.enginesOn;
	}

	void FixedUpdate () {

	}
}
