using UnityEngine;
using System.Collections;

public class ThuribleGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(“space”) && !hit)
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
