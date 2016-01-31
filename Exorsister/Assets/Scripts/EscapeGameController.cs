using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EscapeGameController : MinigameController
{
	public GameObject demon;
	private DemonEscapeScript demonEscape;
    public Text timeText;
    private AudioSource audioS;
	// Use this for initialization
	void Start () 
	{
		demonEscape = demon.GetComponent<DemonEscapeScript> ();
        nextScene = "Win Screen";
        audioS = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
	{
        if (Input.GetMouseButtonDown(0))
        {
            audioS.Play();
        }
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
