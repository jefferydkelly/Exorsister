using UnityEngine;
using System.Collections;

public class ThuribleCubeController : MonoBehaviour {
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
    }
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(key) && isSelected && isColliding)
        {
            //Show hit message
            select(false);
            //tell manager to select a new cube
            controller.SelectCube(gameObject);
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

    public void select(bool selected)
    {
        isSelected = selected;

        if (isSelected)
        {
            if (myRenderer != null)
            {
                myRenderer.material = selectedMat;
            }
        } else
        {
            if (myRenderer != null)
            {
                myRenderer.material = normalMat;
            }
        }
    }
}
