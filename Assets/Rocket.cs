using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour {

    public GameObject podHook;
    public float chainLength = 10;
    public float diff;
    public float forceMag;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
            
	}

	void FixedUpdate () {
		
		if (podHook)
		{
			Vector3 diff_vec = transform.position - podHook.transform.position;
			diff = diff_vec.magnitude;
			
			if (diff_vec.magnitude > chainLength)
			{
				Vector3 direction = Vector3.Normalize(diff_vec);
				podHook.transform.parent.rigidbody.AddForceAtPosition(20000 * direction, podHook.transform.position);
			}
		}
	}

    public void AddForceAtPosition(Vector3 force, Vector3 position)
    {
        rigidbody.AddForceAtPosition(force, position);
        if (podHook)
        {
            Vector3 diff_vec = transform.position - podHook.transform.position;
            diff = diff_vec.magnitude;

            if (diff_vec.magnitude > chainLength)
            {
                Vector3 direction = Vector3.Normalize(diff_vec);
                podHook.transform.parent.rigidbody.AddForceAtPosition(force.magnitude * 10 * direction, podHook.transform.position);
                forceMag = force.magnitude;
            }
        }
    }
}
