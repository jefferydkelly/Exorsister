using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FlyGameController : MonoBehaviour {
    public Text timeRemainingText;
    public Text fliesRemainingText;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        fliesRemainingText.text = "Flies Remaining: " + FlyController.flies.Count;
	}
}
