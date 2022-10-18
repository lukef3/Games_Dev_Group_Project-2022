using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{   enum BombStates { Waiting, Held, Thrown, Landed, Exploding}
    BombStates currentState = BombStates.Waiting;
    FTScript timerFT;
    TimerScript bombTimer;

    Vector3 Velocity, Acceleration;
    private float BombTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Acceleration = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {   
        switch(currentState)
        {
            case BombStates.Waiting:

                break;

            case BombStates.Held:

                break;

            case BombStates.Thrown:

                Velocity += Acceleration * Time.deltaTime;
                transform.position += Velocity * Time.deltaTime;

                Collider[] objsHit = Physics.OverlapSphere(transform.position, 0.02f);
                foreach(Collider obj in objsHit)
                {
                    TileScript possibleTile = obj.transform.GetComponent<TileScript>();
                    if (possibleTile)
                    {
                        currentState = BombStates.Landed;
                        bombTimer = gameObject.AddComponent<TimerScript>();
                        bombTimer.setCooldown(BombTime);
                        GameObject FTGO = Instantiate(StaticFeatures.test, transform);
                        timerFT = FTGO.GetComponent<FTScript>();
                        timerFT.setColour(Color.red);
                    }

                    else
                    {
                        BombScript possibleSelf = obj.transform.GetComponent<BombScript>();
                        if (possibleSelf)
                        {
                            if (possibleSelf != this)
                            {
                                currentState = BombStates.Exploding;
                            }
                        }
                       

                      

                    }

 
                }
                break;
            case BombStates.Landed:
                timerFT.setText(((int) bombTimer.RemainingTime).ToString());
                if (bombTimer.RemainingTime <= 0)
                    currentState = BombStates.Exploding;

                break;

            case BombStates.Exploding:


                break;
        }


    }

    public void BombThrow(Vector3 Dir, float Speed)
    {
        Velocity = (Dir + Vector3.up) * Speed;
        Acceleration = new Vector3(0, -9.8f, 0);
        transform.parent = null;
        currentState = BombStates.Thrown;

    }

    internal void IvePickedYou(JoeControlScript joe)
    {
        currentState = BombStates.Held;
        transform.parent = joe.myRightHand;
        transform.localPosition = Vector3.zero;
    }
}
