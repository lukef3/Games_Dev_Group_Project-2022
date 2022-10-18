using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScorePrefab : MonoBehaviour
{

    public Transform ScoreTemplate;
    public float x, y, z;
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
        Score.setPosition(new Vector2(x, y));

        if (Input.GetKeyDown(KeyCode.Space))
        {          
            Health.setPosition(new Vector2(100, 100));
            Score.setPosition(new Vector2(100, 100));
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
