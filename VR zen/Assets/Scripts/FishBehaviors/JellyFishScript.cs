using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFishScript : MonoBehaviour
{
    //JellyFishscript is the movement behavior for all jellyfish like animals in the underwater scene
    //It moves an object straight up and down, with sinewave motion, and moves up at a much faster speed than it falls

    //verticalDistance is a float that controls how much an object moves up and down- the sinewave's amplitude
    public float verticalDistance;
    //speed is a float that controls the base fall and rise speed for the jellyfish
    public float speed;
    //timer is a float which updates as the functions run in order to update the object's y position
    private float timer = 0;
    //startPosition is a 3D vector used to capture the initial spawn location of the object, which we found was necessary in order to 
    //have the jellyfish motion work as intended
    private Vector3 startPosition;

    //new and lastPositions are 3D vectors used to determine whether or not the object is moving up or down
    private Vector3 lastPosition;
    private Vector3 newPosition;
    
    //called before frame one/before the object is instantiated
    void start(){
        //captures the startLocation of the object
        startPosition = transform.position;
    }
    //update is called once every frame
    void Update(){
        //checks if object is moving up or down
        if(newPosition.y > lastPosition.y){
            //if moving up, increment timer by 5x speed
            timer += Time.deltaTime * speed*5;
        }else{
            //if moving down, increment timer normally
            timer += Time.deltaTime * speed;
        }
        //call move function
        move();
    }

    //move is a function which updates the object's movement and keeps track of the current and previous location
    void move(){
        //sets the last position
        lastPosition = transform.position;
        //gets the values for the object's new location
        float newY = Mathf.Sin(timer) * verticalDistance;
        float x = lastPosition.x;
        float z = lastPosition.z;
        //defines a position vector based on the new values
        Vector3 pos = new Vector3(x,newY,z);
        //sets new position to the start position + the new values
        newPosition = startPosition + pos;
        //Debug.Log(newY)
        //sets new position 
        transform.position = newPosition;


    }
    
}
