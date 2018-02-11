using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EscapeGameController : MinigameController
{
    private AudioSource audioS;
 
	// Use this for initialization
	void Start () 
	{
        base.Start();
        gameTimer.OnComplete.AddListener(Win);

        nextScene = "Win Screen";
        audioS = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
	{
        TimerManager.Instance.Update(Time.deltaTime);
        if (Input.GetMouseButtonDown(0))
        {
            audioS.Play();
        }
	}
}
