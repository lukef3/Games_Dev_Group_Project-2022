using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpTimer : MonoBehaviour
{
    FTScript pickUpTimerFT;
    private float pickUpTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        /*GameObject FTGO = Instantiate(StaticFeatures.test, transform);
        pickUpTimerFT = FTGO.GetComponent<FTScript>();
        pickUpTimerFT.setColour(Color.red);*/
    }

    // Update is called once per frame
    void Update()
    {
        pickUpTime -= Time.deltaTime;

        print(pickUpTime);

        //pickUpTimerFT.setText(((int)pickUpTime).ToString());

        if (pickUpTime <= 0)
        {
            if (BombScript.PickUpItemStates.Waiting == 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
