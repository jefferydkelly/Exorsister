using UnityEngine;
using System.Collections;

public class ThuribleGame : MinigameController {
    public bool hit = false;
    public float time = 15f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space) && !hit)
        {
            hit = true;
        }

        if (time == 0)
        {
            Win();
        }
    }



    void OnTriggerEnter(Collider col)
    {
        hit = false;
    }

    void OnTriggerExit(Collider col)
    {
        if (!hit)
        {
            Lose();
        }
    }
}
