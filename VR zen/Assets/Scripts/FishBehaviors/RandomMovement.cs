using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    //Random movement is a very important script for fish behavior, given horizontal and vertical borders, and speeds for how 
    //fast the object should move, RandomMovement will generate random points within the border for the object to move to
    //then look at that targetLocation and move itself to the position before generating a new point and repeating the processs

    public GameObject topBorder;
    //border that object will not pass
    public GameObject horizontalBorder; 
    //movementSpeed
    public float moveSpeed;
    //How fast the object turns to face the new point
    public float lookSpeed;

    //TargetLocation is a vector that is the position that the object is trying to move to
    private Vector3 TargetLocation;
    //lookingAtTarget is true if the transform.forward of an object is pointing towards the target location and false any other time
    private bool lookingAtTarget;
    //rotateProgress is a float between 0 and 1 that deternines how complete it's looking movement is
    private float rotateProgress;

    //start and destination are quaternions (what unity uses for its rotation properties), and are used to smoothly transition from where the object is looking at,
    //to where it should be looking at
    private Quaternion destination;
    private Quaternion start;
    
    // Start is called before the first frame update
    void Start()
    {
        //Sets targetLocation, destination, and start for the rest of the program to run smoothly
        TargetLocation = GenerateNewPoint();
        destination = GetFaceLocation();
        start = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        //sets rotateAmount to be the time between frames multiplied by how fast the object should be looking at its new target
        float rotateAmount = Time.deltaTime * lookSpeed;
        //if the object has reached the location, generate a new point, and resets all values to what they were originally
        if(Vector3.Distance(TargetLocation, transform.position) < 0.5f){
            TargetLocation = GenerateNewPoint();
            lookingAtTarget = false;
            rotateProgress = 0.00f;
            //Debug.Log("At Location");
            destination = GetFaceLocation();
            start = transform.rotation;
        }
        //if object has not fully turned
        if(rotateProgress < 1 - rotateAmount){
            //Debug.Log(rotateProgress);
            //set rotate progress to increase by rotateAmount
            rotateProgress+= rotateAmount;
            //updates the rotation of the object, based on how done the turn is
            transform.rotation = Quaternion.Slerp(start, destination, rotateProgress);
        }else{
            //when object is done turning, set lookingAtTarget to true
            transform.rotation = destination;
            lookingAtTarget = true;
        }
        //if lookingAtTarget is true, move forward
        if(lookingAtTarget){
            Move();            
        }
    }

    //GenerateNewPoint creates and returns a new point that is within the top and bottom boundaries
    Vector3 GenerateNewPoint(){
        //Get the border positions that are important for use
        float center = topBorder.transform.position.y;
        float radius = horizontalBorder.GetComponent<CapsuleCollider>().radius;
        //Generate random X, Y, and Z coordinates based on the borders
        float X = Random.Range(-radius, radius);
        float Y = Random.Range(0f, center*2f);
        float Z = Random.Range(-radius, radius);
        //create and return a new vector based on generated values
        Vector3 newPosition = new Vector3(X,Y,Z);
        return newPosition;
    }

    //GetFaceLocation returns what rotation is needed for the object to move from looking at where it is currently moved, to where it should be looking at
    Quaternion GetFaceLocation(){
        //gets what the current rotation is
        Quaternion from = transform.rotation;
        //looks at the targetLocation
        transform.LookAt(TargetLocation);
        //sets a new quaternion that stores where the object should be looking
        Quaternion to = transform.rotation;
        //resets the rotation to the old value
        transform.rotation = from;
        //returns the new wanted rotation
        return to;
    }


    //This Move function is pretty simple, just makes it move forward based on the time between frames and the movement speed instance variable
    void Move(){
        Vector3 moveAmount = transform.forward*Time.deltaTime;
        transform.position += moveAmount*moveSpeed;
    }


}
