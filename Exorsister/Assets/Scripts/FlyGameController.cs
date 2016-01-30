using UnityEngine;
using UnityEngine.UI;
#if UNITY_5_3
using UnityEngine.SceneManagement;
#endif
using System.Collections;

public class FlyGameController : VehicleControler {
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

    //we will make an array(or list) of spawned in flies(or locus)
    //and then find the average position and location of them divide by the number
    //or just make all the flies seperate from eachother(check to see if they are too close)

    /// <summary>
    /// Adding up all the forces and then sendign them to the VehicleController to then be added to acceleration
    /// </summary>
    protected override void CalcSteeringForces()
    {

    }

    public void Win()
    {
		//SceneManager.LoadScene(nextScene);
#if UNITY_5_3
		SceneManager.LoadScene("Win Screen");
#else
		Application.LoadLevel("Win Screen");
#endif
	}

	public void Lose()
    {
#if UNITY_5_3
		SceneManager.LoadScene("Game Over");
#else
		Application.LoadLevel("Game Over");
#endif
	}
}
