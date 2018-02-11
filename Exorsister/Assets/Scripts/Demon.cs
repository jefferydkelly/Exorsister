using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : ClickableObject {

    Vector3 startPoint = Vector3.zero;
    float speedMod = 5.0f;
    float maxDistance = 5.0f;

    private void Awake()
    {
        startPoint = transform.position;
    }

    public override void OnClick()
    {
		transform.position = startPoint;
		int direction = Random.Range(0, 8);

		transform.rotation = Quaternion.identity;
        transform.Rotate(0, 0, direction * 45);
    }

	void Update()
	{
        transform.position += transform.up * Time.deltaTime * speedMod;

        if (Vector3.Distance(transform.position, startPoint) > maxDistance) {
            EventManager.TriggerEvent("GameOver");
        }
	}

}
