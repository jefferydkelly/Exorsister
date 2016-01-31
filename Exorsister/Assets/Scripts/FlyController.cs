using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FlyController : VehicleControler {
    
    private float speed = 5.0f;

    //WEIGHTING!!!!
    public float seekWeight = 150.0f;
    //Safe distance
    public float safeDist = 10.0f;
    public float avoidWeight = 80.0f;

    public float mouseDist;

    private Vector3 force;

    //variable weight for the vectors
    public float alignW, seperateW, cohW, fleeW, seekW, lesserSeekW, inBoundsW, wanderW;
    public float sepDist;
    public static List<FlyController> flies;
    float dist;

    public Vector3 velDir;
    public Vector3 velCenter;
	// Use this for initialization
	void Start () {
	    if (FlyController.flies == null)
        {
            FlyController.flies = new List<FlyController>();
        }
        FlyController.flies.Add(this);
    }
	
    /// <summary>
    /// Used for adding up forces
    /// </summary>
    protected override void CalcSteeringForces()
    {
        CalcFlockDir();
        CalcFlockCenter();

        force = Vector3.zero;

        Vector3 flockingForce = Vector3.zero;

        dist = Vector3.Distance(GetMousePos(), transform.position);
        if (dist <= mouseDist)
        {
            flockingForce += Flee(GetMousePos()) * fleeW;
            flockingForce += Seek(new Vector3(0, 0, 0)) * lesserSeekW;
        } else
        {
            flockingForce += Seek(Vector3.zero) * seekW;
            flockingForce += Alignment(velDir) * alignW;
            flockingForce += Seperation(sepDist, flies) * seperateW;
            flockingForce += Cohesion(velCenter) * cohW;
        }
        force += flockingForce;
        force += Wander() * wanderW;

        force = Vector3.ClampMagnitude(force, maxForce);
  
        ApplyForce(force);
    }

    private void CalcFlockDir()
    {
        float x = 0;
        float y = 0;
        float z = 0;

        for (int i = 0; i < flies.Count; i++)
        {
            velDir = flies[i].velocity.normalized;
            x += velDir.x;
            y += velDir.y;
        }

        x /= flies.Count;
        y /= flies.Count;

        velDir = new Vector3(x, y, z);
    }

    public void CalcFlockCenter()
    {
        float x = 0;
        float y = 0;
        float z = 0;

        for (int i = 0; i < flies.Count; i++)
        {
            x += flies[i].transform.position.x;
            y += flies[i].transform.position.y;
        }

        x /= flies.Count;
        y /= flies.Count;
        z = 0;
        velCenter = new Vector3(x, y, z);
    }


}
