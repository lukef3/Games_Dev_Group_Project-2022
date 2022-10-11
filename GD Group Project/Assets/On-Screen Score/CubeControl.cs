using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControl : MonoBehaviour
{

    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {        
        if (Input.GetKey(KeyCode.UpArrow)) transform.position += new Vector3(0, 0, 1) * Time.deltaTime;
        if (Input.GetKey(KeyCode.RightArrow)) transform.position += new Vector3(1, 0, 0) * Time.deltaTime;
        //if (Input.GetKey(KeyCode.RightArrow)) transform.Rotate(Transform.up, 90) * Time.deltaTime;
        if (Input.GetKey(KeyCode.DownArrow)) transform.position += new Vector3(0, 0, -1) * Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftArrow)) transform.position += new Vector3(-1, 0, 0) * Time.deltaTime;
    }
}
