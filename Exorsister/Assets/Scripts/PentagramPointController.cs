using UnityEngine;
using System.Collections;

public class PentagramPointController : GameObjectController {
    private SpriteRenderer spriteRenderer;
    private bool isSelected = false;
    public PentagramPointController pair;
    public PentagramGameController controller;
   
	// Use this for initialization
	void Awake () {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public bool IsSelected {
        get {
            return isSelected;
        }

        set {
            isSelected = value;

            if (isSelected) {
                spriteRenderer.color = Color.red;
			}
			else
			{
                spriteRenderer.color = Color.white;
			}
        }
    }

    private void OnMouseDown()
    {
        if (isSelected) {
            controller.lineUnbroken = true;
            pair.IsSelected = true;
            controller.AddPoint(this);
            IsSelected = false;
        }
    }


    private void OnMouseUp()
    {
        if (isSelected) {
			controller.lineUnbroken = false;
			pair.IsSelected = false; ;
			IsSelected = true;
			controller.RemovePoint(this);
        }
    }

    private void OnMouseOver()
    {
        if (IsSelected && controller.lineUnbroken) {

            IsSelected = false;
			GetComponent<AudioSource>().Play();
            controller.AddPoint(this);
			if (controller.phase < 3)
			{
                pair.IsSelected = true;

			}
			
        }
    }
}
