using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FTScript : MonoBehaviour
{

    TMP_Text FloatingText;
    // Start is called before the first frame update
    void Start()
    {
        FloatingText = GetComponentInChildren<TMP_Text>();
        FloatingText.text = "vksdj;ngs;kj";
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void setTextTo(string v)
    {
        FloatingText.text = v;
    }
}
