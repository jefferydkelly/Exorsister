using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ThuribleGame : MinigameController {
   
    public  List<ThuribleCubeController> cubes;
    private AudioSource audio;
    Timer firstSelectTimer;

	// Use this for initialization
	void Start () {
        base.Start();
        firstSelectTimer = new Timer(0.25f);
        firstSelectTimer.OnComplete.AddListener(SelectFirst);
        firstSelectTimer.Start();
        audio = GetComponent<AudioSource>();
        gameTimer.OnComplete.AddListener(Win);
    }

    public void SelectFirst ()
    {
        cubes[2].IsSelected = true;
    }

    public void SelectCube(ThuribleCubeController go)
    {
        audio.Play();
        List<int> indexes = new List<int>();
        indexes.Add(0);
        indexes.Add(1);
        indexes.Add(2);
        indexes.RemoveAt(cubes.IndexOf(go));

        cubes[indexes[Random.Range(0, 2)]].IsSelected = true;
    }
}
