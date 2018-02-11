using UnityEngine;
using UnityEngine.UI;
#if UNITY_5_3
using UnityEngine.SceneManagement;
#endif
using System.Collections;

public class FlyGameController : MinigameController {
    public Text fliesRemainingText;
    public Text hitText;
    Timer clearTimer;

    public void Start()
    {
        base.Start();
        clearTimer = new Timer(1.0f);
        clearTimer.OnComplete.AddListener(ClearHitText);
        EventManager.StartListening("FlySwatted", UpdateFlyCount);
        gameTimer.OnComplete.AddListener(Lose);
        //UpdateFlyCount();
    }

    // Update is called once per frame
    void Update () {
        

        TimerManager.Instance.Update(Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            bool hit = false;
            FlyController toRemove = null;
            foreach (FlyController fly in FlyController.flies) {
                if (fly.IsDead)
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
                clearTimer.Start();
            } else
            {
                hitText.text = "Miss!";
                clearTimer.Start();
            }
        }
	}

    public void ClearHitText()
    {
        hitText.text = "";
    }

    public void UpdateFlyCount() {
        int numFlies = FlyController.flies.Count;
        fliesRemainingText.text = "Flies Remaining: " + numFlies;

        if (numFlies == 0) {
            Win();
        }
    }
}
