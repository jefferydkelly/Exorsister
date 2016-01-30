using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FlyController : VehicleControler {
    
    private float speed = 5.0f;
    private Vector3 forward = new Vector2(1, 0);

    //WEIGHTING!!!!
    public float seekWeight = 150.0f;
    //Safe distance
    public float safeDist = 10.0f;
    public float avoidWeight = 80.0f;
    //public BoundingArea bounds;

    //variable weight for the vectors
    public float alignW, seperateW, cohW, inBoundsW;
    public float sepDist;
    public static List<FlyController> flies;
	// Use this for initialization
	void Start () {
	    if (FlyController.flies == null)
        {
            FlyController.flies = new List<FlyController>();
        }
        FlyController.flies.Add(this);
    }
	
	// Update is called once per frame
	void Update () {
        //transform.position += forward * speed * Time.deltaTime;
	}
    /// <summary>
    /// Used for adding up forces
    /// </summary>
    protected override void CalcSteeringForces()
    {

    }


}
