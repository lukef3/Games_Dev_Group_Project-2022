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

    internal void setPosition(Vector3 v)
    {
        textOfUI.rectTransform.position = v;
    }

    internal void setTextTo(string v)
    {
        textOfUI.text =v ;
    }
}
