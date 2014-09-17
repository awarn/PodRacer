using UnityEngine;
using System.Collections;

public class Track : MonoBehaviour {

    public GameController gameController;
    public Checkpoint startCheckpoint;
    public Checkpoint endCheckpoint;
    public int laps = 1;

	Checkpoint[] checkpoints;

	// Use this for initialization
	void Start () {
		checkpoints = GetComponentsInChildren<Checkpoint> ();
		foreach (Checkpoint checkpoint in checkpoints)
        {
			if (checkpoint != startCheckpoint)
			{
				checkpoint.setVisible(false);
			}
        }
            
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
