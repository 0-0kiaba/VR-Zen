using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    //Pick random spot within border
    //move to location
    //topBorder
    public GameObject topBorder;
    //border that object will not pass
    public GameObject horizontalBorder; 
    //movementSpeed
    public float moveSpeed;
    private Vector3 TargetLocation;
    //How fast the object turns to face the new point
    public float lookSpeed;
    //Coroutine to make object start rotating
    private Coroutine LookCoroutine;
    
    // Start is called before the first frame update
    void Start()
    {
        TargetLocation = GenerateNewPoint();
    }

    // Update is called once per frame
    void Update()
    {

        if(Vector3.Distance(TargetLocation, transform.position) < 0.05f){
            Debug.Log("At Location");
        }else if(Vector3.Dot((transform.position- TargetLocation).normalized,transform.forward)!=1){
            FaceLocation();
        }else{
            Debug.Log("Looking at Object!");
            transform.position = TargetLocation;
        }
    }

    Vector3 GenerateNewPoint(){
        //Get the border positions that are important for use
        float center = topBorder.transform.position.y;
        float radius = horizontalBorder.GetComponent<CapsuleCollider>().radius;
        //Generate random X, Y, and Z coordinates based on the borders
        float X = Random.Range(-radius, radius);
        float Y = Random.Range(center-20f, center+20f);
        float Z = Random.Range(-radius, radius);
        //create and return a new vector based on generated values
        Vector3 newPosition = new Vector3(X,Y,Z);
        return newPosition;
    }

    void FaceLocation(){
        if(LookCoroutine != null){
            StopCoroutine(LookCoroutine);
        }

        LookCoroutine = StartCoroutine(LookAt()); 
    }


    IEnumerator LookAt(){
        Quaternion LookRotation = Quaternion.LookRotation(TargetLocation-transform.position);

        float time = 0;

        while( time < 1 ){
            transform.rotation = Quaternion.Slerp(transform.rotation, LookRotation, time);

            time += Time.deltaTime * lookSpeed;

            yield return null;
        }

    }

    void Move(){
        //Vector3 pos = transform.forward * moveSpeed;
        //transform.position += pos;
    }


}
