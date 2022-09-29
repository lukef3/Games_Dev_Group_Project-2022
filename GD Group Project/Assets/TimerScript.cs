using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour
{

    float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

    }

    public void resetTimer()
    {
        timer = 0;
    }

    public void setCooldown(float cooldown)
    {
        RemainingTime = cooldown;
    }

    public float RemainingTime
    {
        get { if (timer >= 0) return 0f;
            else
                return -timer; }
        set
        {
            timer = -value;
        }
    }

    public float TimePassed()
    {
        return timer;
    }
   
    
}
