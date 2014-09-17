using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

    public Checkpoint nextCheckpoint;

	// Use this for initialization
	void Start () {
        gameObject.tag = "Checkpoint";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setVisible(bool visible)
    {
        gameObject.GetComponent<MeshRenderer>().enabled = visible;
    }
}
