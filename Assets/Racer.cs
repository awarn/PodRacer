using UnityEngine;
using System.Collections;

public class Racer : MonoBehaviour {

    public GameController gameController;

    public Track track;
    public Checkpoint currentCheckpoint;

    public int laps;
    public float currentTime;

	// Use this for initialization
	void Start () {
        gameObject.tag = "Player";
		currentCheckpoint = track.startCheckpoint;
	}
	
	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;
	}

    void OnTriggerEnter( Collider other )
    {
		Debug.Log ("hit");
        if (other.GetComponent<Checkpoint>())
        {
            Checkpoint hitCheckpoint = other.GetComponent<Checkpoint>();
            if ( hitCheckpoint == currentCheckpoint )
            {
                currentCheckpoint.setVisible(false);
                if (currentCheckpoint == track.endCheckpoint)
                {
                    laps++;
                    gameController.postTime(currentTime);
                    currentTime = 0.0f;
                }
                else
                {

                }
                currentCheckpoint = other.GetComponent<Checkpoint>().nextCheckpoint;
                currentCheckpoint.setVisible(true);
            }
            print("Next checkpoint: " + currentCheckpoint);

        }
    }

}
