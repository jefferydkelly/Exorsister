using UnityEngine;
using UnityEngine.UI;
#if UNITY_5_3
using UnityEngine.SceneManagement;
#endif
using System.Collections;

public class FlyGameController : MinigameController {
    public float timeRemaining = 60.0f;
    public Text timeRemainingText;
    public Text fliesRemainingText;
    public Text hitText;


    // Use this for initialization
    void Start () {
        nextScene = "HolyWaterInfoScene";
	}
	
	// Update is called once per frame
	void Update () {
        timeRemaining -= Time.deltaTime;
        timeRemainingText.text = "Time Remaining: " + Mathf.RoundToInt(timeRemaining);
        fliesRemainingText.text = "Flies Remaining: " + FlyController.flies.Count;
        
        if (Input.GetMouseButtonDown(0))
        {
            bool hit = false;
            FlyController toRemove = null;
            foreach (FlyController fly in FlyController.flies) {
                if (fly.IsBeingClicked())
                {
                    toRemove = fly;
                    hit = true;
                }
            }

            if (hit)
            {
                FlyController.flies.Remove(toRemove);
                toRemove.Splat();
                hitText.text = "Yeah!";
                Invoke("ClearHitText", 1.0f);
            } else
            {
                hitText.text = "Miss!";
                Invoke("ClearHitText", 1.0f);
            }
        }
        if (FlyController.flies.Count == 0)
        {
            Win();
        } else if (timeRemaining <= 0)
        {
            Lose();
        }
	}

    public void ClearHitText()
    {
        hitText.text = "";
    }
}
