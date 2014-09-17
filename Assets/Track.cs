using UnityEngine;
using System.Collections;

public class Track : MonoBehaviour {

    public GameController gameController;
    public Checkpoint startCheckpoint;
    public Checkpoint endCheckpoint;
    public int laps = 1;

	// Use this for initialization
	void Start () {
        foreach (Transform child in transform)
        {
            GameObject child_gameobject = child.gameObject;
            if (child_gameobject.tag == "Checkpoint")
            {
                if (child_gameobject.GetComponent<Checkpoint>() != startCheckpoint)
                {
                    child_gameobject.GetComponent<Checkpoint>().setVisible(false);
                }
            }
        }
            
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
