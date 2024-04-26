using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCircleMovementScript : MonoBehaviour
{
    //FishCircleMovement is a script which updates an object's position in order to constantly be rotating around a center point
    //it is going to be used for fish that need to be moving in a circle around the player or another object


    //circle that fish will swim in
    public float radius;
    //how fast fish swims
    public float speed;
    //where the object is rotating around
    public Transform centerPoint;
    //the constant height of the object
    public float y;


    //used to locally keep track of how much time has passed, which affects the circular motion calculator
    private float timer = 0; 


    //called once every frame
    void Update()
    {
        //updates timed based on the time passed since last frame and the speed instance variable
        timer += Time.deltaTime * speed;
        //moves position of object
        Move();
    }

    //This function calculates the correct speed and rotation rate for an object to completely move in a perfect circle
    void Move(){
        //sets new x and z values based on sine and cosine waves and how far the object should be from the centerPoint
        float x = Mathf.Cos(timer) * radius;
        float z = Mathf.Sin(timer) * radius;
        //places these values (including the instance variable y) into a new vector
        Vector3 pos = new Vector3(x, y, z);
        //updates the objects current position based on where the centerpoint is located
        //(moving in a circle around the center)
        transform.position = pos + centerPoint.position;
    }

}
