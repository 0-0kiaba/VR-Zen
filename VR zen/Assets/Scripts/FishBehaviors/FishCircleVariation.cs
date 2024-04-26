using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCircleVariation : MonoBehaviour
{
    //FishCircleVariation is a very similar script to FishCircleMovement, but also adds the ability for the fish to move up and down in a curved motion
    //and also allows the object to move in not just circular movement, adding variables for both the x and z distance

    //objects base y position
    public float y;
    //point object is rotating around
    public Transform centerPoint;
    //speed the object is moving around in a circle
    public float speed;
    //how much the object moves up and down
    public float verticalHeight;
    //Spread of how much the object's x axis moves
    public float xDifference;
    //Spread of how much the object's z axis moves
    public float zDifference;

    

    //float variable that updates as the program runs
    float timer = 0;

    // Update is called once per frame
    void Update()
    {
        //updates the timer based on time since last frame and speed instance variable
        timer += Time.deltaTime * speed;
        //moves the object
        updatedMove();
    }

    //function that moves the objects in an eliptical motion based on x and y difference, as well as moves the object up and down in a sinewave motion
    //based on verticalHeight
    void updatedMove(){
        //moves in the x-Axis based on a cosine wave
        float x = xDifference * Mathf.Cos(timer);
        //moves in the z-axis based on a sine wave
        float z = zDifference * Mathf.Sin(timer);
        //moves the y-axis up and down with sine waves
        float newY = verticalHeight * Mathf.Sin(timer);
        //gives a new vector 3 based on the calculated values
        Vector3 pos = new Vector3(x,newY,z);
        //sets the objects position to be updated based on the center's location
        transform.position = pos + centerPoint.position;
    }
}
