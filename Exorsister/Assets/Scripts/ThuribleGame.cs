using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ThuribleGame : MinigameController {
   
    public float time = 15f;
    public  List<GameObject> gos;
    private AudioSource audio;
	// Use this for initialization
	void Start () {
        Invoke("SelectFirst", 0.25f);
        audio = GetComponent<AudioSource>();
    }

    public void SelectFirst ()
    {
        gos[2].GetComponent<ThuribleCubeController>().select(true);
    }
	
	// Update is called once per frame
	void Update () {

        time -= Time.deltaTime;
        if (time <= 0)
        {
            Win();
        }
    }

    public void SelectCube(GameObject go)
    {
        audio.Play();
        List<int> indexes = new List<int>();
        indexes.Add(0);
        indexes.Add(1);
        indexes.Add(2);
        indexes.RemoveAt(gos.IndexOf(go));
        Debug.Log(gos.IndexOf(go));
        if (Random.Range(0, 2) == 1)
        {
            gos[indexes[0]].GetComponent<ThuribleCubeController>().select(true);
        } else
        {
            gos[indexes[1]].GetComponent<ThuribleCubeController>().select(true);
        }
    }
}
