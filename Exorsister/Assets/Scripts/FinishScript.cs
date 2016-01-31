 using UnityEngine;
using System.Collections;

public class FinishScript : MinigameController {
    public int checkScore = 0;
    public float timer = 20;
	// Use this for initialization
	void Start () {
        nextScene = "FlyInfoScene";
	}
	
    public void increaseScore()
    {
        checkScore++;
        Debug.Log(checkScore);
        if(checkScore == 5)
        {

            Win();
        }
    }

	// Update is called once per frame
	void Update () {
        
        if(timer >= 0)
        {
            timer -= Time.deltaTime;
        }
        else { Lose(); }
	}
}
