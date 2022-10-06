using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIScript : MonoBehaviour
{

    TMP_Text textOfUI;
    // Start is called before the first frame update
    void Start()
    {
       textOfUI =  GetComponentInChildren<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {



       
        
    }


    internal void setrelativeposition(Vector2 v)
    {
        // x = 0 is left  x = 1 right
        // y = 0 is down  y = 1 is up

        Resolution[] resolutions = Screen.resolutions;

        long percentage_x = (Screen.width / 100), percentage_y = (Screen.height / 100);
 
        setPosition(new Vector2(percentage_x, percentage_y));

    }

    internal void setPosition(Vector3 v)
    {
        textOfUI.rectTransform.position = v;
    }

    internal void setTextTo(string v)
    {
        textOfUI.text =v ;
    }
}
