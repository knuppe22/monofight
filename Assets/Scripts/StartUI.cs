using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUI : MonoBehaviour
{
    public GameObject highScoreUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void viewHighScore()
    {
        highScoreUI.SetActive(true);
    }

    public void exitHighScore()
    {
        highScoreUI.SetActive(false);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
