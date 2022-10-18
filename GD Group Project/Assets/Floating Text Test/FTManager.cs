using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FTManager : MonoBehaviour
{

    FTScript newFT;
    public static Transform FTCloneTemplate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (false)
        {
            GameObject GOnew = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            Transform holdFTGO =   Instantiate(FTCloneTemplate);

          newFT = holdFTGO.GetComponent<FTScript>();
            newFT.transform.parent = GOnew.transform;
        }
    }
}
