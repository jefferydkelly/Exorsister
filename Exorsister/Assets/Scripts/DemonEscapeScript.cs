using UnityEngine;
using System.Collections;

public class DemonEscapeScript : GameObjectController
{
	Vector3 center;

	public float time = 15.0f;
	int direction; // Number 0-7 for which direction he's heading
	// Use this for initialization
	private bool escaped = false;
	float speedMod;

	GameObject g;

	void Start () 
	{
		direction = (int)Random.Range(0,8);
		center = new Vector3 (0, 1, 0);
		speedMod = 5.0f;
		g = gameObject.GetComponent("GameObject").gameObject;
	}
	
	// Update is called once per frame
	void Update ()
	{

		int rotate = 0;

		//Debug.Log (time);
		time -= Time.deltaTime;
		if (time > 0) 
		{
			if (Input.GetMouseButtonDown (0)) {
				Vector3 screenMouse = new Vector3 (GetMousePos ().x, GetMousePos ().y, 10);
				Vector3 realMouse = Camera.main.ScreenToWorldPoint (screenMouse);

				if (realMouse.x >= 0) {	
					if (Vector3.Angle (center, realMouse) > ((direction * 45) - 22) && Vector3.Angle (center, realMouse) < ((direction * 45) + 23)) {
						transform.position = center;
						direction = (int)Random.Range (0, 8);
					}
				} else {
					if (((180 - Vector3.Angle (center, realMouse)) + 180 > ((direction * 45) - 22)) && ((180 - Vector3.Angle (center, realMouse)) + 180) < ((direction * 45) + 23)) {
						transform.position = center;
						direction = (int)Random.Range (0, 8);
					}
				}

				if ((direction == 0) && ((Vector3.Angle (center, realMouse)) < 23)) {
					transform.position = center;
					direction = (int)Random.Range (0, 8);
				}
			}

			switch (direction) {
			case 2:
				transform.Translate ((Vector3.right * Time.deltaTime) * speedMod);
				rotate = 90;
				break;
			case 1:
				transform.Translate ((((Vector3.right + Vector3.up) / 2) * Time.deltaTime) * speedMod);
				rotate = 45;
				break;
			case 0:
				transform.Translate ((Vector3.up * Time.deltaTime) * speedMod);
				rotate = 0;
				break;
			case 7:
				transform.Translate ((((Vector3.left + Vector3.up) / 2) * Time.deltaTime) * speedMod);
				rotate = 315;
				break;
			case 6:
				transform.Translate ((Vector3.left * Time.deltaTime) * speedMod);
				rotate = 270;
				break;
			case 5:
				transform.Translate ((((Vector3.left + Vector3.down) / 2) * Time.deltaTime) * speedMod);
				rotate = 225;
				break;
			case 4:
				transform.Translate ((Vector3.down * Time.deltaTime) * speedMod);
				rotate = 180;
				break;
			case 3:
				transform.Translate ((((Vector3.right + Vector3.down) / 2) * Time.deltaTime) * speedMod);
				rotate = 135;
				break;
			default:
				print ("ERROR");
				break;
			}

			if (rotate != null)
			{
				g.transform.Rotate(0,0,rotate);
			}
		}
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
