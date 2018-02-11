using UnityEngine;
using System.Collections;
using System;

public class GameObjectController : ClickableObject {
    
	public Vector3 GetMousePos()
	{
		return Input.mousePosition;
	}
}
