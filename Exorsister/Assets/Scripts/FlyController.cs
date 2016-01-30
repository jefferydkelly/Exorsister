using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FlyController : GameObjectController {
    
    private float speed = 5.0f;
    private Vector3 forward = new Vector2(1, 0);
    public static List<FlyController> flies;
	// Use this for initialization
	void Start () {
	    if (flies == null)
        {
            flies = new List<FlyController>();
        }
        flies.Add(this);
    }
	
	// Update is called once per frame
	void Update () {
        //transform.position += forward * speed * Time.deltaTime;

        if (IsBeingClicked())
        {
            FlyController.flies.Remove(this);
            Destroy(gameObject);
        }
	}
}
