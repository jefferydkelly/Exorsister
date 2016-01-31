using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EscapeGameController : MinigameController
{
	public GameObject demon;
	private DemonEscapeScript demonEscape;
    public Text timeRemainingText;
    public 
	// Use this for initialization
	void Start () 
	{
		demonEscape = demon.GetComponent<DemonEscapeScript> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
        timeRemainingText.text = "Time Remaining: " + Mathf.FloorToInt(demonEscape.time);
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
