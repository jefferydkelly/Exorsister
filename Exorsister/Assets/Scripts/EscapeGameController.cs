using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EscapeGameController : MinigameController
{
	public GameObject demon;
	private DemonEscapeScript demonEscape;
    public Text timeText;
	// Use this for initialization
	void Start () 
	{
		demonEscape = demon.GetComponent<DemonEscapeScript> ();
        nextScene = "Win Screen";
	}
	
	// Update is called once per frame
	void Update ()
	{
        timeText.text = "Time Remaining: " + Mathf.RoundToInt(demonEscape.time);
		if (demonEscape.Escaped) 
		{
			Lose ();
		}

		if (demonEscape.time <= 0) 
		{
			Win ();
		}
	}
}
