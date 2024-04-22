using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCircleMovementScript : MonoBehaviour
{
    //circle that fish willl swim in
    public float radius;
    //how fast fish swims
    public float speed;
    //where the object is rotating around
    public Transform centerPoint;
    //the constant height of the object
    public float y;


    //timer to locally keep track of the timer
    private float timer = 0; 

    //calls before the first frame



    //This function calculates the correct speed and rotation rate for an object to completely move in a perfect circle
    void Update()
    {
        timer += Time.deltaTime * speed;
        Move();
        transform.LookAt(centerPoint);
    }

    void Move(){
        float x = Mathf.Cos(timer) * radius;
        float z = Mathf.Sin(timer) * radius;
        Vector3 pos = new Vector3(x, y, z);
        transform.position = pos + centerPoint.position;
    }

}
