using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GUIText timeText;

    public Track track;
    public Racer player;

    private float bestTime = float.MaxValue;

	// Use this for initialization
	void Start () {
        Checkpoint start = track.startCheckpoint;
        player.currentCheckpoint = start;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void postTime(float time)
    {
        timeText.text = "<p>Last time: " + time.ToString("n4")+"</p>";
        if (time < bestTime)
        {
            bestTime = time;
        }
        timeText.text += "<p>Best time: " + bestTime.ToString("n4") + "</p>";
    }

}
