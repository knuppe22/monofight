using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverUI : MonoBehaviour
{ 
    public TextMeshProUGUI Text_GameResult;
    public TextMeshProUGUI Text_Best;

    // public RuntimeAnimatorController originPlayer;

    private void Start()
    {
        Show();
        Time.timeScale = 0f;
    }

    public void Show()
    {
        /*
        // 플레이어, UI 비활성화
        GameObject.FindWithTag("Player").GetComponent<Player>().enabled = false;
        GameObject.Find("JumpBtn").GetComponent<Button>().interactable = false;
        GameObject.Find("Joystick").GetComponent<VariableJoystick>().enabled = false;
        */

        // 점수 계산, 데이터 저장
        int score = GameManager.Instance.score;
        GameSaveData.Instance.SaveScore(score);
        int best = GameSaveData.Instance.GetMaxScores()[0];
        Text_GameResult.text = "Score : " + score.ToString();
        Text_Best.text = "High Score : " + best.ToString();
    }

    public void OnClick_Retry()
    {
        // retry 시 점수 리셋
        GameManager.Instance.score = 0;

        /*
        // 플레이어 상태 리셋
        player.GetComponent<Animator>().runtimeAnimatorController = originPlayer;
        */

        Time.timeScale = 1f; 

        // 다시 메인씬 로드
        SceneChange.Instance.OnLoadMainScene();
    }

    public void OnClick_Menu()
    {
        GameManager.Instance.score = 0;
        SceneChange.Instance.OnLoadStartScene();
    }
}
