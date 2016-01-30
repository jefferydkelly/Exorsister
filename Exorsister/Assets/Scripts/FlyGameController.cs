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

    private float speed = 5.0f;
    private Vector3 forward = new Vector2(1, 0);



    //WEIGHTING!!!!----------------------
    //Safe distance
    public float avoidWeight = 80.0f;
    //variable weight for the vectors
    public float alignW, seperateW, cohW;
    public float sepDist;


    // Use this for initialization
    void Start () {
	
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
                Destroy(toRemove.gameObject);
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
