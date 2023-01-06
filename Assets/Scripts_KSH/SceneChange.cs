using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void OnLoadStartScene()
    {
        // ��ŸƮ �� �ε�
        SceneManager.LoadScene("Start_KSH");
    }

    public void OnLoadMainScene()
    {
        // ���� �� �ε�
        //GameObject.Find("GameData").GetComponent<GameSaveData>().LoadData();
        SceneManager.LoadScene("MainScene");
    }

    public void OnLoadEndScene()
    {
        // ���� �� �ε�
        SceneManager.LoadScene("End_KSH");
    }
}
