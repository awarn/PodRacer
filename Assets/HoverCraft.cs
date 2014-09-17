using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HoverCraft : MonoBehaviour {

    public List<Transform> HoverPoints = new List<Transform>();
    public float HoverHeight = 7;
    public float HoverForceFront = 200;
    public float HoverForceBack = 400;

    public Vector3 temp;

    private bool isGrounded = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        //Lift
        for (int i = 0; i < 4; i++)
        {
            RaycastHit Hit;
            if (i > 1)
            {
                if (Physics.Raycast(HoverPoints[i].position, HoverPoints[i].TransformDirection(Vector3.down), out Hit, HoverHeight))
                {
                    temp = (Vector3.up * HoverForceBack * Time.deltaTime) * Mathf.Abs(1 - (Vector3.Distance(Hit.point, HoverPoints[i].position) / HoverHeight));
                    rigidbody.AddForceAtPosition((Vector3.up * HoverForceBack * Time.deltaTime) * Mathf.Abs(1 - (Vector3.Distance(Hit.point, HoverPoints[i].position) / HoverHeight)), HoverPoints[i].position);
                }
                if (Hit.point != Vector3.zero)
                {
                    Debug.DrawLine(HoverPoints[i].position, Hit.point, Color.blue);
                }
            }
            else
            {
                if (Physics.Raycast(HoverPoints[i].position, HoverPoints[i].TransformDirection(Vector3.down), out Hit, HoverHeight))
                {
                    rigidbody.AddForceAtPosition((Vector3.up * HoverForceFront * Time.deltaTime) * Mathf.Abs(1 - (Vector3.Distance(Hit.point, HoverPoints[i].position) / HoverHeight)), HoverPoints[i].position);
                }
                if (Hit.point != Vector3.zero)
                {
                    Debug.DrawLine(HoverPoints[i].position, Hit.point, Color.red);
                } 
            }
            if (Hit.point != Vector3.zero)
                isGrounded = true;
            else
                isGrounded = false;
        }
	}
}
