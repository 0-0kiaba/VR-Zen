using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCircleVariation : MonoBehaviour
{

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

    


    //float variable that 
    float timer = 0;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * speed;
        updatedMove();
        transform.LookAt(centerPoint);
    }

    //function that 
    void updatedMove(){
        float x = xDifference * Mathf.Cos(timer);
        float z = zDifference * Mathf.Sin(timer);
        float newY = verticalHeight * Mathf.Sin(timer);
        Vector3 pos = new Vector3(x,newY,z);
        transform.position = pos + centerPoint.position;
    }
}
