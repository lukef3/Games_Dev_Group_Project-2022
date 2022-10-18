using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTestScript : MonoBehaviour
{
    BombScript myBomb;
    public Transform BombTemplate;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
          Transform newBomb =  Instantiate(BombTemplate);
          myBomb =  newBomb.GetComponent<BombScript>();
            myBomb.transform.position =
                new Vector3(Random.Range(-10f, 10f), 0f, Random.Range(-10f, 10f));


        }

 


    }
}
