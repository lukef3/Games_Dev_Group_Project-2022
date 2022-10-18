using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FTScript : MonoBehaviour
{

    TMP_Text FloatingText;
    TimerScript my_timer;
    // Start is called before the first frame update
    void Start()
    {
        my_timer = gameObject.AddComponent<TimerScript>();
        my_timer.setCooldown(10);
        FloatingText = GetComponentInChildren<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        FloatingText.text = my_timer.RemainingTime.ToString("0");
        print(my_timer.RemainingTime);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            my_timer.setCooldown(20);
        }
    }
}
