using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FlyGameController : MinigameController {
    public float timeRemaining = 60.0f;
    public Text timeRemainingText;
    public Text fliesRemainingText;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timeRemaining -= Time.deltaTime;
        timeRemainingText.text = "Time Remaining: " + Mathf.RoundToInt(timeRemaining);
        fliesRemainingText.text = "Flies Remaining: " + FlyController.flies.Count;
        
        if (FlyController.flies.Count == 0)
        {
            Win();
        } else if (timeRemaining <= 0)
        {
            Lose();
        }
	}
}
