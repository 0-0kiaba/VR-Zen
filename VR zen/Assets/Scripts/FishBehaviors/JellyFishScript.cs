using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFishScript : MonoBehaviour
{
    public float verticalDistance;
    public float speed;
    float timer = 0;
    private Vector3 startPosition;

    Vector3 lastPosition;
    Vector3 newPosition;
    

    void start(){
        startPosition = transform.position;
    }
    void Update(){
        if(newPosition.y > lastPosition.y){
            timer += Time.deltaTime * speed*5;
        }else{
            timer += Time.deltaTime * speed;
        }
        move();
    }


    void move(){
        lastPosition = transform.position;
        float newY = Mathf.Sin(timer) * verticalDistance;
        float x = lastPosition.x;
        float z = lastPosition.z;
        Vector3 pos = new Vector3(x,newY,z);
        newPosition = startPosition + pos;
        //Debug.Log(newY)
        transform.position = newPosition;


    }
    //sin function but very fast speed when the wave is moving up
    
}
