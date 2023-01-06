using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    /*
    public Text Text_GameResult;
    public Text Text_Best;
    public Text gameOverText;
    public string gameOverMsg = "";

    public RuntimeAnimatorController originPlayer;
    */

    public void Start()
    {
        Show();
        Time.timeScale = 0f;
    }

    public void Show()
    {
        /*
        // 플레이어, UI 비활성화
        GameObject.FindWithTag("Player").GetComponent<Player>().enabled = false;
        GameObject.FindWithTag("Player").GetComponent<PlayerDesktop>().enabled = false;
        GameObject.Find("JumpBtn").GetComponent<Button>().interactable = false;
        GameObject.Find("Joystick").GetComponent<VariableJoystick>().enabled = false;

        // 점수 계산, 데이터 저장
        int score = FindObjectOfType<Score>().Getfinal();
        FindObjectOfType<GameSaveData>().SaveScore(score);
        int best = FindObjectOfType<GameSaveData>().GetMaxScore();
        Text_GameResult.text = "Score : " + score.ToString();
        Text_Best.text = "Best : " + best.ToString();

        if (gameOverText != null)
        {
            gameOverText.text = gameOverMsg;
        }
        */
    }

    public void OnClick_Retry()
    {
        /*
        // retry 시 점수 리셋
        FindObjectOfType<Score>().Scorereset();

        // 플레이어 상태 리셋
        GameObject player = GameObject.FindWithTag("Player");
        player.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        player.GetComponent<Animator>().runtimeAnimatorController = originPlayer;


        Time.timeScale = 1f;//테스트신
        // 게임 저장된 데이터 리셋
        GameSaveData.isSuperJump = false;
        GameSaveData.life = 3;
        */

        // 다시 메인씬 로드
        SceneManager.LoadScene("MainScene");
        
    }

    public void OnClick_Quit()
    {
        Application.Quit();
    }
}
