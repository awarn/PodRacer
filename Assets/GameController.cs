using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GUIText lastTimeText;
	public GUIText bestTimeText;

    public Track track;

    private float bestTime = float.MaxValue;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void postTime(float time)
    {
		lastTimeText.text = "LAST: " + time.ToString("n3");
        if (time < bestTime)
        {
            bestTime = time;
        }
		bestTimeText.text = "BEST: " + bestTime.ToString("n3");
    }

}
