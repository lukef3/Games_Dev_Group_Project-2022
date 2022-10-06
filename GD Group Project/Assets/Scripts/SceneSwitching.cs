using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitching : MonoBehaviour
{
   public void playLevel()
    {
        SceneManager.LoadScene("SecondScene");
    }

    public void goBack()
    {
        SceneManager.LoadScene("MainScene");
    }

    //To exit when User presses Exit in the menu
    public void exitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting"); //For testing 
    }

    //To exit when User presses *Esc*
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
            Debug.Log("Game will exit"); //For testing 
        }
    }
}
