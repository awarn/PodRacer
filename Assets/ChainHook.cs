using UnityEngine;
using System.Collections;

public class ChainHook : MonoBehaviour {
	
	public Transform target;
	public float distance = 5.0f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!target || !transform.parent) {
			return;
		}
		
		Vector3 wantedAlignment = Vector3.Normalize( target.position - transform.position );
		
		Vector3 wantedPosition = target.position + -wantedAlignment * distance;
		
		transform.parent.position = wantedPosition;
	}
}