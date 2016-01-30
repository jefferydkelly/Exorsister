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
		print (direction);
	}
	
	// Update is called once per frame
	void Update () 
	{
		/*switch(direction)
		{
		case 0:
			transform.Translate (Vector3.right *Time.deltaTime);
			break;
		case 1:
			transform.Translate (((Vector3.right + Vector3.up)/2) *Time.deltaTime);
			break;
		case 2:
			transform.Translate (Vector3.up *Time.deltaTime);
			break;
		case 3:
			transform.Translate (((Vector3.left + Vector3.up)/2) *Time.deltaTime);
			break;
		case 4:
			transform.Translate (Vector3.left *Time.deltaTime);
			break;
		case 5:
			transform.Translate (((Vector3.left + Vector3.down)/2) *Time.deltaTime);
			break;
		case 6:
			transform.Translate (Vector3.down *Time.deltaTime);
			break;
		case 7:
			transform.Translate (((Vector3.right + Vector3.down)/2) *Time.deltaTime);
			break;
		default:
			print ("ERROR");
		}*/
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
