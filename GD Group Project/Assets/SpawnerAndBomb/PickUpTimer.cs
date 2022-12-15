using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpTimer : MonoBehaviour
{
    FTScript pickUpTimerFT;
    private float pickUpTime = 30f;
    private GameObject FTGO;
    // Start is called before the first frame update
    void Start()
    {
        FTGO = Instantiate(StaticFeatures.test, this.gameObject.transform);
        pickUpTimerFT = FTGO.GetComponent<FTScript>();
        pickUpTimerFT.SetColour(Color.black);
        FTGO.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        pickUpTime -= Time.deltaTime;


        if(pickUpTime < 11 && pickUpTime >=1)
        {
            FTGO.SetActive(true);
            pickUpTimerFT.SetText(((int)pickUpTime).ToString());
        }

        if(pickUpTime < 6)
        {
            pickUpTimerFT.SetColour(Color.yellow);
        }

        if (pickUpTime <= 1)
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
        Destroy(pickUpTimerFT);
        Destroy(this);
    }
}
