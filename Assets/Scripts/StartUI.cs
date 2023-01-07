using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartUI : MonoBehaviour
{
    public GameObject highScoreUI;
    public TextMeshProUGUI highScore1_text;
    public TextMeshProUGUI highScore2_text;
    public TextMeshProUGUI highScore3_text;



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
        highScore1_text.text = "Rank 1 : " + GameSaveData.Instance.GetMaxScores()[0];
        highScore2_text.text = "Rank 2 : " + GameSaveData.Instance.GetMaxScores()[1];
        highScore3_text.text = "Rank 3 : " + GameSaveData.Instance.GetMaxScores()[2];

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
