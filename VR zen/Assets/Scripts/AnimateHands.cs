using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//makes sure the animator is in the script for it to work
[RequireComponent(typeof(Animator))]

public class AnimateHandController : MonoBehaviour
{
    [Header("Reference to what controller grip does at different values")]
    public InputActionReference gripInputActionReference;
    [Header("Reference to what controller trigger does at different values")]
    public InputActionReference triggerInputActionReference;

    //the animation tree that tells what values do what
    private Animator handAnimator;
    //Trigger value (from 0 to ine)
    private float triggerVal;
    //grip value (from 0 to 1)
    private float gripVal;

    // Start is called before the first frame update
    void Start()
    {
        //grab and assign animator to handAnimator
        handAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    //Animate based on grip and trigger input values
    void Update()
    {
        AnimateGrip();
        AnimateTrigger();
    }
    
    //get val of grip and input it in the handAnimator
    private void AnimateGrip(){
        gripVal = gripInputActionReference.action.ReadValue<float>();
        handAnimator.SetFloat("Grip", gripVal);
    }

    //get val of trigger and input it in the handAnimator
    private void AnimateTrigger(){
        triggerVal = triggerInputActionReference.action.ReadValue<float>();
        handAnimator.SetFloat("Trigger", triggerVal);
    }
}