using UnityEngine;
using System.Collections;

public class DemonEscapeScript : GameObjectController
{

	int direction; // Number 0-7 for which direction he's heading
	// Use this for initialization
	private bool escaped = false;
	void Start () 
	{
		direction = (int)Random.Range(0,8);
	}
	
	// Update is called once per frame
	void Update () 
	{
		//transform.Translate (Vector3.right * Time.deltaTime);
	}

	void OnTriggerExit(Collider col)
	{
		escaped = true;
	}

	public bool Escaped 
	{
		get 
		{
			return escaped;
		}
	}

}
