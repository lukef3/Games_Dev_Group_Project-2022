using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScorePrefab : MonoBehaviour
{

    public Transform ScoreTemplate;

    UIScript Score, Health;
    // Start is called before the first frame update
    void Start()
    {
        Transform holdScore = Instantiate(ScoreTemplate);
        Score = holdScore.GetComponent<UIScript>();
  
        Transform holdHealth = Instantiate(ScoreTemplate);
        Health = holdHealth.GetComponent<UIScript>();
  
    }
  

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Score.setPosition(new Vector3(540, 0, 0));
            Health.setPosition(new Vector3(540, 0, 0));
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            Health.setTextTo("Health" + "\n123");
            Score.setTextTo("");
        }


        if (Input.GetKeyDown(KeyCode.S))
        {
            Health.setTextTo("");
            Score.setTextTo("Score" + "\n321");
        }




    }
}
