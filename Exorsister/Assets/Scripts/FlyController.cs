using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FlyController : VehicleControler {
    
    private float speed = 5.0f;

    //WEIGHTING!!!!
    //Safe distance
    public float safeDist = 10.0f;
    public float avoidWeight = 80.0f;

    public float mouseDist;//the distance the locus will flee from the mouse at

    //the ULTIMATE FORCE (TM) for adding movement to the flies(locus)
    private Vector3 force;

    //variable weight for the vectors
    public float alignW, seperateW, cohW, inBoundsW, seekW, fleeW, lesserSeekW, wanderW;
    public float sepDist;
    public static List<FlyController> flies;
    float dist;

    //vectors for the center of the flock and the direction
    public Vector3 velDir;//the direction the flock is facing
    public Vector3 velCent;//the center of the flock

    // Use this for initialization
    void Start () {
	    if (FlyController.flies == null)
        {
            FlyController.flies = new List<FlyController>();
        }
        FlyController.flies.Add(this);
    }
	
	// Update is called once per frame

    /// <summary>
    /// Used for adding up forces
    /// </summary>
    protected override void CalcSteeringForces()
    {
        CalcFlockDir();
        CalcFlockDir();

        force = Vector3.zero;
        Vector3 flockingForce = Vector3.zero;

            dist = Vector3.Distance(GetMousePos(), transform.position);//getting the area (distance) from mouse to locus
            if(dist <= mouseDist)//if the fly is within the area of the mouse, the flies will flee
            {
                flockingForce += Flee(GetMousePos())*fleeW;
            flockingForce += Seek(new Vector3(1, 0, 0))*lesserSeekW;
            }
            else if(dist > mouseDist)
        {
            flockingForce += Seek(new Vector3(0, 0, 0)) * seekW;
            flockingForce += Alignment(velDir)*alignW;
            flockingForce += Seperation(sepDist, flies)*seperateW;
            flockingForce += Cohesion(velCent)*cohW;
        }
      
        force += flockingForce;
        force += Wander() * wanderW;
        force = Vector3.ClampMagnitude(force, maxForce);
        
        ApplyForce(force);//applying the forces to the acceleration to then be added
    }

    private void CalcFlockDir()
    {
        float x = 0;
        float y = 0;
        float z = 1;
        for(int i = 0; i < flies.Count; i++)
        {
            velDir = flies[i].velocity;
            velDir = velDir.normalized;
            x += velDir.x;
            y += velDir.y;
            z += velDir.z;
        }
        x = x / flies.Count;
        y = y / flies.Count;
        z = 0;//z is going to be default 1

        velDir = new Vector3(x, y, z);
    }

    private void CalFlockCenter()
    {
        float x = 0;
        float y = 1;
        float z = 0;
        for(int i = 0; i<flies.Count; i++)
        {
            velCent= flies[i].velocity;
            velCent = velCent.normalized;
            x += flies[i].transform.position.x;
            y += flies[i].transform.position.y;
            //z += velCent.z;
        }
        x = x / flies.Count;
        y = y / flies.Count;
        z = 0;//z is going to be default 1

        velCent = new Vector3(x, y, z);
    }


}
