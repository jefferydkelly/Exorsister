using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
public class MinigameWinScreenControiller :InfoScreenController {
    public List<AudioClip> clips;

	// Use this for initialization
	void Start () {
        int ind = Random.Range(0, clips.Count);
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clips[ind];
        audio.Play();
	}
}
