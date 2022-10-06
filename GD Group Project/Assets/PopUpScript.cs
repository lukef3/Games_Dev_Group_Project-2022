using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpScript : MonoBehaviour
{
    // Start is called before the first frame update
    enum PopUpStates { Introduction, Waiting, NearEnd, End}
    PopUpStates my_state = PopUpStates.Introduction;
    float RotationSpeed = 90f;
    float x = 0;
    Renderer my_renderer;

    Color startColor;
    void Start()
    {
        my_renderer = GetComponent<Renderer>();
        startColor = my_renderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        switch(my_state)
        {
            case PopUpStates.Introduction:
                x += 0.3f * Time.deltaTime;
                 my_renderer.material.color = new Color(startColor.r,startColor.g, startColor.b, x);
                if (Input.GetKey(KeyCode.Return))
                    my_state = PopUpStates.Waiting;
                break;

            case PopUpStates.Waiting:
                transform.Rotate(new Vector3(5, 8, 1), RotationSpeed * Time.deltaTime);


                break;

            case PopUpStates.NearEnd:

         
                break;


            case PopUpStates.End:
                //Player collects coin
                void OnCollisionEnter(Collision other)
                {
                    if (other.gameObject.tag == "PopUp")
                    {
                        Destroy(gameObject);
                        //or gameObject.SetActive(false);
                    }
                }

                //or coin disappears after some certain time


                break;


        }


 
    }
}
