using UnityEngine;
using System.Collections;

public class EscapeGameController : MinigameController
{
	public GameObject demon;
	private DemonEscapeScript demonEscape;
	// Use this for initialization
	void Start () 
	{
		demonEscape = demon.GetComponent<DemonEscapeScript> ();
        nextScene = "Win Screen";
	}
	
	// Update is called once per frame
	void Update ()
	{
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
