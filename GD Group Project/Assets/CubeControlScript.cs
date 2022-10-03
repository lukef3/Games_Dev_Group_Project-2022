using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CubeControlScript : MonoBehaviour
{
    public TMP_Text healthText;
    int health = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateTextBoxes()
    {
        healthText.text = health.ToString();
    }

    private void OnMouseDown()
    {
        health -= 1;
        UpdateTextBoxes();
    }
}
