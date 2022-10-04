using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#
public class JoeControlScript : MonoBehaviour
{
    enum CharacterStates {Grounded, JumpUp, Falling }

    CharacterStates joe_state = CharacterStates.Grounded;
    private Vector3 jumping_velocity;
    float start_jump_velocity = 5;

    private float walking_speed = 2;
    private float running_speed = 4;
    float current_speed = 0;

    Animator joe_animator;
    private float rotation_speed = 180;
    private float gravity = 10;

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



        switch (joe_state)
        {
            case CharacterStates.Grounded:
                joe_animator.SetBool("isWalking", false);
                joe_animator.SetBool("isWalkingBackwards", false);
                if (shouldWalkForward()) walk_forward();
                if (shouldWalkBackwards()) walk_backwards();
                if (shouldTurnLeft()) turn_left();
                if (shouldTurnRight()) turn_right();

                if (shouldJump()) jump();
                transform.position += current_speed * transform.forward * Time.deltaTime;
                break;




            case CharacterStates.JumpUp:
                transform.position += jumping_velocity  * Time.deltaTime ;
                jumping_velocity -= gravity*Vector3.up * Time.deltaTime;
                 
                if (jumping_velocity.y <0f)
                {
                    joe_state = CharacterStates.Falling;
                }
                break;


            case CharacterStates.Falling:

                transform.position += jumping_velocity * Time.deltaTime;
                jumping_velocity -= gravity*Vector3.up * Time.deltaTime;
                Debug.DrawLine(transform.position, transform.position - Vector3.down);
                Collider[] colliding_with = Physics.OverlapBox(transform.position, new Vector3(0.5f, 0.1f, 0.5f));
                foreach (Collider c in colliding_with)
                {
                    joe_animator.SetBool("isLanding", true);
                    joe_animator.SetBool("isJumping", false);
                    joe_animator.SetBool("isLanding", true);
                    joe_state = CharacterStates.Grounded;

                }

                break;


        }


       
 

  




    }

    private void jump()
    {
        joe_animator.SetBool("isJumping", true);
        joe_state = CharacterStates.JumpUp;

        jumping_velocity =  current_speed* transform.forward +  start_jump_velocity* Vector3.up;


    }

    private bool shouldJump()
    {
        return Input.GetKey(KeyCode.Space);
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
        current_speed = -walking_speed;

    }

    private bool shouldWalkBackwards()
    {
        return Input.GetKey(KeyCode.S);
    }

    private void walk_forward()
    {
        joe_animator.SetBool("isWalking",true);
        current_speed = walking_speed;
    }

    private  bool shouldWalkForward()
    {
        return Input.GetKey(KeyCode.W);
    }
}
