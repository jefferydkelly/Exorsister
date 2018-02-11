using UnityEngine;
using System.Collections;

public class ThuribleCubeController : ClickableObject {
    public Material normalMat;
    public Material selectedMat;
    public bool isSelected;
    private Renderer myRenderer;
    public KeyCode key;
    private bool isColliding = false;
    private ThuribleGame controller;
	// Use this for initialization
	void Start () {
        myRenderer = GetComponent<Renderer>();
        controller = Camera.main.GetComponent<ThuribleGame>();
        if (myRenderer != null)
        {
            myRenderer.material = normalMat;
        }

        if (Application.isMobilePlatform) {
            transform.localScale *= 2;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(key))
        {
            Check();
        }
	}

    public override void OnClick()
    {
        if (Application.isMobilePlatform) {
            Check();
        }
    }

    void Check() {
        if (IsSelected && isColliding) {
			IsSelected = false;
			//tell manager to select a new cube
			controller.SelectCube(this);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        isColliding = true;
    }

    void OnTriggerExit(Collider col)
    {
        if (isSelected)
        {
            controller.Lose();
        }

        isColliding = false;
    }

    public bool IsSelected {
        get {
            return isSelected;
        }

        set {
            isSelected = value;

			if (isSelected)
			{
				if (myRenderer != null)
				{
					myRenderer.material = selectedMat;
				}
			}
			else
			{
				if (myRenderer != null)
				{
					myRenderer.material = normalMat;
				}
			}
        }
    }
}
