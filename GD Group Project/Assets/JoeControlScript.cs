using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class JoeControlScript : NetworkBehaviour,Health
{
    enum CharacterStates {Grounded, JumpUp, Falling }

    internal Transform myRightHand, myLeftHand;


    PickUP rightHand, leftHand;

    [SerializeField]
    private GameObject Bullet;
    [SerializeField]
        private Transform WaterpistolTransform; //Reference to waterpistol//
    [SerializeField]
    private Transform BulletParent; //place all the bullet under this parent//
    [SerializeField]
    private float bulletHitMissDistance = 25f;

    

    CharacterStates joe_state = CharacterStates.Grounded;
    private Vector3 jumping_velocity;
    float start_jump_velocity = 10;

    private float walking_speed = 5;
    private float running_speed = 4;
    float current_speed = 0;

    Animator joe_animator;
    private float rotation_speed = 180;
    private float gravity = 10;
    private float dirBoost = 2;

    // Start is called before the first frame update
    void Start()
    {
         getHands();

        joe_animator = GetComponent<Animator>();
        if (joe_animator)
            print("Found");
        else
            print("Animator not found");

    }

    private Transform getHands()
    {
        Transform[] allBones = transform.GetComponentsInChildren<Transform>();
        foreach (Transform bone in allBones)
        {
            if (bone.name == "HoldRight")
            {
                myRightHand= bone;

            }
            if (bone.name == "HoldLeft")
            {
                myLeftHand = bone;

            }



        }

        return null;
    }

    // Update is called once per frame
    void Update()
    {

        //if (!IsOwner) return;


        current_speed = 0;


        switch (joe_state)
        {
            case CharacterStates.Grounded:
                joe_animator.SetBool("isWalking", false);
                joe_animator.SetBool("isWalkingBackwards", false);
                if (shouldWalkForward()) walk_forward();
                if (shouldWalkBackwards()) walk_backwards();
                if (shouldTurnLeft()) turn_left();
                if (shouldTurnRight()) turn_right();
                if (shouldPickUp()) pickUp();
                if (shouldUseRight()) useRight();
                if (shouldPointGun()) pointGun();
                else
                     unPointGun();
                if (shouldFireGun()) FireGun();
                else
                    UnFireGun();
                
  
                
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


                Collider[] colliding_with = Physics.OverlapBox(transform.position, new Vector3(0.5f, 0.1f, 0.5f));
                foreach (Collider c in colliding_with)
                {   
                    print(c.tag);

                    if (c.tag == "Tile")
                    {
                        joe_animator.SetBool("isLanding", true);
                        joe_animator.SetBool("isJumping", false);
                   
                        joe_state = CharacterStates.Grounded;
                    }

                }

                break;


        }


       
 

  




    }

    private void UnFireGun()
    {
        joe_animator.SetBool("isFiring", false);
    }

    private void unPointGun()
    {
        joe_animator.SetBool("isPointing", false);
    }

    private void pointGun()
    {

            joe_animator.SetBool("isPointing", true);
        



    }

    private bool shouldPointGun()
    {
        return Input.GetMouseButton(1);
           
    }
    private Transform cameraTransform;
    private void FireGun()
     {
        joe_animator.SetBool("isFiring", true);
       
        RaycastHit hit;

        GameObject bullet = GameObject.Instantiate(Bullet, WaterpistolTransform.position, Quaternion.identity, BulletParent);
        BulletController bulletController = Bullet.GetComponent<BulletController>();
        if (Physics.Raycast(cameraTransform.position,cameraTransform.forward,out hit, Mathf.Infinity)) //Mathf is the distance for the raycast to follow// 
        {
                   
            
            bulletController.target = hit.point;
                     bulletController.hit = true;
                
        }
        else
        {

            bulletController.target = cameraTransform.position + cameraTransform.forward * bulletHitMissDistance;
            bulletController.hit = false;
        }

    }

     private bool shouldFireGun()
     {
        return Input.GetMouseButton(0);
     }
 

    private void useRight()
    {
        if (rightHand is BombScript )
        {
            (rightHand as BombScript).BombThrow(transform.forward, 5);
            rightHand = null;
        }

        if (rightHand is GunScript)
        {
            (rightHand as GunScript).GunFire();
        }
       
    }

    private void useLeft()
    {
        if(leftHand is BombScript)
        {

            (leftHand as BombScript).BombThrow(transform.forward, 5);
            leftHand = null;
        }

        if(leftHand is GunScript)
        {
            (leftHand as GunScript).GunFire();
        }

    }

    private bool shouldUseRight()
    {
        return Input.GetKeyDown(KeyCode.T);
    }

    

    private void pickUp()
    {
    Collider[] allPossiblePickUps = Physics.OverlapSphere(transform.position, 1f);
    foreach (Collider c in allPossiblePickUps)
        {
           
            PickUP newItem = c.transform.GetComponent<PickUP>();

            
            if (newItem && (newItem.currentState != PickUP.PickUpItemStates.Held))

            {   if (rightHand == null)
                {

                    joe_animator.SetBool("isPickingUp", true);
                    rightHand = newItem;
                    newItem.latestOwner(this, myRightHand);
                }

            else
                
              if (leftHand == null)
                    {
                        joe_animator.SetBool("isPickingUp", true);
                    leftHand = newItem;
                    newItem.latestOwner(this,myLeftHand);

                }
            }



          
        }
    
    }

    private bool shouldPickUp()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    private void jump()
    {
        joe_animator.SetBool("isJumping", true);
        joe_animator.SetBool("isLanding", false);
        joe_state = CharacterStates.JumpUp;

        jumping_velocity =  dirBoost *current_speed* transform.forward +  start_jump_velocity* Vector3.up;


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

    public void Take_Damage(float damage)
    {
        throw new NotImplementedException();
    }
}
