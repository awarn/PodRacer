using UnityEngine;
using System.Collections;

public class ChainLink : MonoBehaviour {

	public Transform target;
	public float distance = 10.0f;
	public float lenght = 2.0f;

    public Vector3 wantedPosition;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!target || !rigidbody) {
			return;
		}

        Vector3 diff_vec = target.position - transform.position;

        if (diff_vec.magnitude >= distance)
        {

        }
		Vector3 direction = Vector3.Normalize( diff_vec );
        //wantedPosition = target.position - -direction * distance;
        rigidbody.AddForce(direction * 15000);
		//transform.position = wantedPosition;
	}
}