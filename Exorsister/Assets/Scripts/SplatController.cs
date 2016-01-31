using UnityEngine;
using System.Collections;

public class SplatController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("Kill", 3.0f);
	}
	
	void Kill()
    {
        Destroy(gameObject);
    }
}
