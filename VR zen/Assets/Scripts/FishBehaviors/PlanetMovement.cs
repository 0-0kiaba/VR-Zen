using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMovement : MonoBehaviour
{

    public float speed;
    float currentY;

    void Start(){
        currentY = transform.rotation.y;
    }
    // Update is called once per frame
    void Update()
    {
        currentY += Time.deltaTime * speed;
        //transform.Rotate(transform.rotation.x, transform.rotation., currentZ);
        transform.Rotate(transform.rotation.x, currentY, transform.rotation.z);
    }
}
