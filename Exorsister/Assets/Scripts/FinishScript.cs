 using UnityEngine;
using System.Collections;

public class FinishScript : MonoBehaviour {
    public int checkScore = 0;
    public float timer = 20;
	// Use this for initialization
	void Start () {
	
	}
	
    public void increaseScore()
    {
        checkScore++;
        if(checkScore == 5)
        {
            
            winGame();
        }
    }

    void winGame()
    {
        Destroy(gameObject);
    }

    void looseGame()
    {

    }
	// Update is called once per frame
	void Update () {
        
        if(timer >= 0)
        {
            timer -= Time.deltaTime;
        }
        else { looseGame(); }
	}
}
