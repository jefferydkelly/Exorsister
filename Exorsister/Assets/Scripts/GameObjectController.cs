using UnityEngine;
using System.Collections;

public class GameObjectController : MonoBehaviour {
    
    public bool IsMouseOver()
    {
        RaycastHit hit;
        Vector3 mp2 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(mp2);
        mousePos.z = -1;

        if (Physics.Raycast(mousePos, new Vector3(0, 0, 1), out hit, float.MaxValue))
        {
            if (hit.collider == gameObject.GetComponent<Collider>())
            {
                return true;
            }
        }
        return false;
    }
    public bool IsBeingClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            return IsMouseOver();
        }
        return false;
    }

    public bool IsMouseBeingDraggedOver()
    {
        if (Input.GetMouseButton(0))
        {
            return IsMouseOver();
        }
     	return false;
    }

	public Vector3 GetMousePos()
	{
		return Input.mousePosition;
	}
}
