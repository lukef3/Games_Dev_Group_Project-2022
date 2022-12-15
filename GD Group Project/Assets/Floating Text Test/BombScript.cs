using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : PickUP
{ 
    FTScript timerFT;
    TimerScript bombTimer;
    public GameObject boom;

    GameObject FTGO;

    public Material bombMat;
    public Material heatingUpMat;
    Renderer rend;

    Vector3 Velocity, Acceleration;
    private float BombTime = 4f;

    // Start is called before the first frame update
    void Start()
    {
        Acceleration = new Vector3(0, 0, 0);
        rend = GetComponent<Renderer>();
        rend.material = bombMat;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case PickUpItemStates.Waiting:
                
               
                break;

            case PickUpItemStates.Held:
                rend.material = bombMat;
                Destroy(FTGO);
                break;

            case PickUpItemStates.Thrown:

                Velocity += Acceleration * Time.deltaTime;
                transform.position += Velocity * Time.deltaTime;

                transform.rotation = Quaternion.identity;

                Collider[] objsHit = Physics.OverlapSphere(transform.position, 0.05f);
                foreach(Collider obj in objsHit)
                {
                    TileScript possibleTile = obj.transform.GetComponent<TileScript>();
                    if (possibleTile)
                    {
                        currentState = PickUpItemStates.Landed;
                        bombTimer = gameObject.AddComponent<TimerScript>();
                        bombTimer.setCooldown(BombTime);
                        FTGO = Instantiate(StaticFeatures.test, transform);
                        timerFT = FTGO.GetComponent<FTScript>();
                        timerFT.SetColour(Color.red);
                    }

                    else
                    {
                        BombScript possibleSelf = obj.transform.GetComponent<BombScript>();
                        if (possibleSelf)
                        {
                            if (possibleSelf != this)
                            {
                                currentState = PickUpItemStates.DoYourThing;
                            }
                        }
                    }
                }
                break;

            case PickUpItemStates.Landed:
                timerFT.SetText(((int) bombTimer.RemainingTime).ToString());
                rend.material = heatingUpMat;
                if (bombTimer.RemainingTime <= 1)
                    currentState = PickUpItemStates.DoYourThing;

                break;

            case PickUpItemStates.DoYourThing:

                objsHit = Physics.OverlapSphere(transform.position, 5f);
                foreach (Collider obj in objsHit)
                {
                    TileScript possibleTile = obj.transform.GetComponent<TileScript>();
                    if (possibleTile)
                    {
                        
                        float dist = Vector3.Distance(this.transform.position, possibleTile.transform.position);
                        TakeDamage(possibleTile, dist);
                        Instantiate(boom, transform.position, transform.rotation);
                        Destroy(gameObject);
                    }
                }

                break;
        }


    }

    private void TakeDamage(TileScript possibleTile, float dist)
    {
        if(dist <= 10)
        {
            possibleTile.Take_Damage(100);
        }
    }

    public void BombThrow(Vector3 Dir, float Speed)
    {
        Velocity = (Dir + Vector3.up) * Speed;
        Acceleration = new Vector3(0, -9.8f, 0);
        transform.parent = null;
        currentState = PickUpItemStates.Thrown;

    }


}
