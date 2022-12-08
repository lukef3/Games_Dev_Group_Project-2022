using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpTimer : MonoBehaviour
{
    FTScript pickUpTimerFT;
    public float pickUpTime = 40f;
    private GameObject FTGO;
    // Start is called before the first frame update
    void Start()
    {
        FTGO = Instantiate(StaticFeatures.test, this.gameObject.transform);
        pickUpTimerFT = FTGO.GetComponent<FTScript>();
        pickUpTimerFT.SetColour(Color.black);
    }

    // Update is called once per frame
    void Update()
    {
        pickUpTime -= Time.deltaTime;

        print(pickUpTime); 

        /*if(BombScript.PickUpItemStates.Held == 0)
        {
            Destroy(FTGO);
        }*/

        pickUpTimerFT.SetText(((int)pickUpTime).ToString());

        if (pickUpTime <= 0)
        {
            if (PickUP.PickUpItemStates.Waiting == 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    internal void remove()
    {
        Destroy(FTGO);
        Destroy(this);
    }
}
