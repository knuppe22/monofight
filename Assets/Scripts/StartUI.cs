using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUI : MonoBehaviour
{
    public GameObject highScoreUI;

    // Start is called before the first frame update
    void Start()
    {
        // TODO: high score 불러오는 기능
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneChange.Instance.OnLoadMainScene();
    }

    public void ViewHighScore()
    {
        highScoreUI.SetActive(true);
    }

    public void ExitHighScore()
    {
        highScoreUI.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
