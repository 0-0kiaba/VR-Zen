using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishLookAt : MonoBehaviour
{
    //FishLookAt is a very simple script designed to simply always make an object face another object
    //This script is used for the circling fish, because their preset spawns now have an invisible gameObject indicating what direction is in front of them at all time
    //fixing a previous bug with the circling behavior
    //what the object will always be facing
    
    public Transform lookingAt;
    
    // Update is called once per frame
    void Update()
    {
        //objects transform.forward looks at lookingAt
        transform.LookAt(lookingAt);
    }
}
