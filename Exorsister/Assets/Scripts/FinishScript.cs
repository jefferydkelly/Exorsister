 using UnityEngine;
using System.Collections;

public class FinishScript : MinigameController {
    public int checkScore = 0;
	// Use this for initialization
	void Start () {
        base.Start();
        gameTimer.OnComplete.AddListener(Lose);
	}
	
    public void increaseScore()
    {
        checkScore++;
        if(checkScore == 5)
        {

            Win();
        }
    }
}
