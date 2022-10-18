using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{

    public Transform bulletCloneTemplate;

    enum GunStates { Waiting, Held, Firing}
    GunStates currentState = GunStates.Waiting;
    FTScript timerFT;
    TimerScript bombTimer;

    Vector3 Velocity, Acceleration;
    private float BulletTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Acceleration = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case GunStates.Waiting:

                break;

            case GunStates.Held:

                break;

            case GunStates.Firing:

                break;


        }


    }

    public void GunFire(Vector3 Dir, float Speed)
    {
        Velocity = (Dir + Vector3.up) * Speed;
        Acceleration = new Vector3(0, -9.8f, 0);
        transform.parent = null;
        currentState = GunStates.Firing;

    }

    internal void IvePickedYou(JoeControlScript joe)
    {
        currentState = GunStates.Held;
        transform.parent = joe.myRightHand;
        transform.localPosition = Vector3.zero;
    }
}
