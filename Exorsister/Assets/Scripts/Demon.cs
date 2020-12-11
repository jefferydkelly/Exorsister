using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : ClickableObject {

    Vector3 startPoint = Vector3.zero;
    float speedMod = 4.0f;
    float maxDistance = 5.0f;

    [SerializeField]
    AudioClip[] soundFX;
    AudioSource src;
    private void Awake()
    {
        startPoint = transform.position;
        src = GetComponent<AudioSource>();
    }

    public override void OnClick()
    {
        //transform.position = startPoint;
       
		int direction = Random.Range(3, 6);

		//transform.rotation = Quaternion.identity;
        transform.Rotate(0, 0, direction * 45);
        src.PlayOneShot(soundFX[Random.Range(0, 3)], 0.125f);
    }

	void Update()
	{
        transform.position += transform.up * Time.deltaTime * speedMod;

        if (Vector3.Distance(transform.position, startPoint) > maxDistance) {
            EventManager.TriggerEvent("GameOver");
        }
	}

}
