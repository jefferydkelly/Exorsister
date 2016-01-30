using UnityEngine;
using System.Collections;

public class DemonEscapeScript : MonoBehaviour {

	int direction; // Number 0-7 for which direction he's heading
	// Use this for initialization
	void Start () 
	{
		direction = (int)Random.Range(0,8);
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate (Vector3.right * Time.deltaTime);
	}

	void OnTriggerExit(Collider col)
	{
		print ("test");

		//{
			//End Game
		//	print("Game Over");
		//}
	}

	void OnTriggerEnter(Collider col)
	{
		print ("test");
	}
}
