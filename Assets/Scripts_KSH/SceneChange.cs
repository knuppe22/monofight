using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void OnLoadStartScene()
    {
        // 스타트 씬 로드
        SceneManager.LoadScene("Start_KSH");
    }

    public void OnLoadMainScene()
    {
        // 메인 씬 로드
        //GameObject.Find("GameData").GetComponent<GameSaveData>().LoadData();
        SceneManager.LoadScene("MainScene");
    }

    public void OnLoadEndScene()
    {
        // 엔드 씬 로드
        SceneManager.LoadScene("End_KSH");
    }
}
