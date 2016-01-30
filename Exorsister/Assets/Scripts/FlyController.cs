using UnityEngine;
using System.Collections;

public class FlyController : MonoBehaviour {
    
    private float speed = 5.0f;
    private Vector3 forward = new Vector2(1, 0);
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += forward * speed * Time.deltaTime;
	}
}
