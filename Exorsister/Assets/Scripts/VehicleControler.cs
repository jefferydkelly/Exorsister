using UnityEngine;
using System.Collections;

using System.Collections.Generic;

abstract public class VehicleControler : GameObjectController {

    // Use this for initialization
    //movement
    protected Vector3 acceleration;
    public Vector3 velocity;
    protected Vector3 desired;
    protected Vector3 seekBounds;
    protected Vector3 forward;

    //public for changing in Inspector
    //define movement behaviors
    public float maxSpeed;
    public float maxForce;
    public float mass;
    public float radius;
    public float wanderDistance;
    public float wanderRadius;

    void Start () {
        acceleration = Vector3.zero;
        velocity = new Vector3(1, 0, 0);
    }

    /// <summary>
    /// Used for calculating the steering forces and adding them up. Will be called from the fly or whatever is accessing them
    /// </summary>
    abstract protected void CalcSteeringForces();

    // Update is called once per frame
    void Update () {
        CalcSteeringForces();
        //Debug.Log ("acceleration: " + acceleration.x + " " + acceleration.y + " " + acceleration.z);
        velocity += acceleration * Time.deltaTime;
        velocity.z = 0;//setting the z location to be default 1 for now

        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        transform.position += velocity * Time.deltaTime;

        //reset
        acceleration = Vector3.zero;
        forward = velocity.normalized;
    }

    /// <summary>
    /// Adding up the forces and applying them to the acceleration
    /// </summary>
    /// <param name="steeringForce"></param>
    protected void ApplyForce(Vector3 steeringForce)
    {
        acceleration += steeringForce / mass;
    }

    //the fleeing method 
    /// <summary>
    /// the flies will be fleeing from the mouse position
    /// </summary>
    /// <param name="moveFrom"></param>
    /// <returns></returns>
    protected Vector3 Flee(Vector3 moveFrom)
    {
        desired = transform.position - moveFrom;
        desired = desired.normalized * maxSpeed;
        desired -= velocity;
        desired.z = 0;
        return desired;
    }


    //seperation away from other safe objects
    public Vector3 Seperation(float sepDist, List<FlyController> flies)
    {
        //Vector3[] flockDis = new Vector3[gm.Flock.Count];
        float dist = sepDist;//default 
        Vector3 steerFrom = Vector3.zero;//steering away from that vehicle's position
        for (int i = 0; i < flies.Count; i++)
        {
            dist = Vector3.Distance(flies[i].transform.position, transform.position);
            //if the other vehicle is too close, steer away.
            if (dist > 0 && dist < sepDist)
            {
                steerFrom =flies[i].transform.position;
                //Debug.DrawLine(transform.position,steerFrom,Color.cyan);

            }

        }

        return Flee(steerFrom);
    }

    //the seek method
    protected Vector3 Seek(Vector3 targetPos)
    {
        desired = targetPos - transform.position;
        desired = desired.normalized * maxSpeed;
        //Debug.Log ("Desired: " + desired.x + " " + desired.y + " " + desired.z);
        //Debug.Log ("velocity: " + velocity.x + " " + velocity.y + " " + velocity.z);
        if (Vector3.Dot(desired, velocity) < 0)
        {
            desired -= velocity;
            desired.z = 0;//dont need to seek y, only z and x
        }
        else {
            desired += velocity;
            desired.z = 0;//dont need to seek y, only z and x
        }

        //desired.y = 0;
        return desired;
    }

    //alignment with other objects
    //steer behicle towards flocker's average direction
    //direction
    public Vector3 Alignment(Vector3 alignVect)
    {
        //passing in direction vector from gamemanager
        Vector3 desireVel = alignVect;//setting vel to the averaged vector found in gm.
        desireVel = desireVel.normalized;
        desireVel = desireVel * maxSpeed;
        Vector3 steer = desireVel - velocity;
        //Debug.DrawLine(transform.position,alignVect,Color.yellow);

        return steer;
    }

    //steer towards flocker's average direction
    //centroid
    public Vector3 Cohesion(Vector3 cohVect)
    {
        //passing in centroid from gamemanager to seek
        //Debug.DrawLine(transform.position,cohVect,Color.black);
        return Seek(cohVect);

    }

    public Vector3 Wander()
    {
        float ang = Random.Range(0, Mathf.PI * 2);
        Vector3 v = transform.position + forward * wanderDistance;
        v += new Vector3(Mathf.Cos(ang), Mathf.Sin(ang)) * wanderRadius;
        return Seek(v);
    }

}
