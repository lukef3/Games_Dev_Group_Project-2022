using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoeControlScript : MonoBehaviour
{
    private float walking_speed = 2;
    Animator joe_animator;
    private float rotation_speed = 180;

    // Start is called before the first frame update
    void Start()
    {
        
        joe_animator = GetComponent<Animator>();
        if (joe_animator)
            print("Found");
        else
            print("Animator not found");

    }

    // Update is called once per frame
    void Update()
    {
        
        joe_animator.SetBool("isWalking", false);
        joe_animator.SetBool("isWalkingBackwards", false);

        if (shouldWalkForward()) walk_forward();
        if (shouldWalkBackwards()) walk_backwards();
        if (shouldTurnLeft()) turn_left();
        if (shouldTurnRight()) turn_right();




    }

    private void turn_right()
    {
        joe_animator.SetBool("isWalkingBackwards", true);
        transform.Rotate(Vector3.up, rotation_speed * Time.deltaTime);
    }

    private bool shouldTurnRight()
    {
        return Input.GetKey(KeyCode.D);
    }

    private void turn_left()
    {
        joe_animator.SetBool("isWalkingBackwards", true);
        transform.Rotate(Vector3.up, -rotation_speed * Time.deltaTime);
    }

    private bool shouldTurnLeft()
    {
        return Input.GetKey(KeyCode.A);
    }

    private void walk_backwards()
    {
        joe_animator.SetBool("isWalkingBackwards", true);
        transform.position -= walking_speed * transform.forward * Time.deltaTime;
    }

    private bool shouldWalkBackwards()
    {
        return Input.GetKey(KeyCode.S);
    }

    private void walk_forward()
    {
        joe_animator.SetBool("isWalking",true);
        transform.position +=walking_speed* transform.forward * Time.deltaTime;
    }

    private  bool shouldWalkForward()
    {
        return Input.GetKey(KeyCode.W);
    }
}
