using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FTScript : MonoBehaviour
{

    TMP_Text FloatingText;
    private Color textColor;

    // Start is called before the first frame update
    void Start()
    {
        FloatingText = GetComponentInChildren<TMP_Text>();
    }

    internal void SetText(String textMessage)
    {
        FloatingText.text = textMessage;
    }

    // Update is called once per frame
    void Update()
    {
        if (FloatingText)
            FloatingText.color = textColor;

        Vector3 FTtoCamera = Camera.main.transform.position - transform.position;

        transform.rotation = Quaternion.LookRotation(-FTtoCamera.normalized, Vector3.up);
  
    }

    internal void SetColour(Color colorProvided)
    {
        textColor = colorProvided;
    }
}
