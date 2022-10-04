using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CubeControlScript : MonoBehaviour
{
    public TMP_Text FloatingText;
    public ParticleSystem Explosion;

    TimerScript my_timer;

    // Start is called before the first frame update
    void Start()
    {
        my_timer = gameObject.AddComponent<TimerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { 
            my_timer.setCooldown(10);
        }

        UpdateTextBoxes();
        print(my_timer.RemainingTime);

        if(my_timer.RemainingTime == 0)
        {
            Explosion.Play();
        }
    }

    void UpdateTextBoxes()
    {
        FloatingText.text = my_timer.RemainingTime.ToString("0");
    }
}
