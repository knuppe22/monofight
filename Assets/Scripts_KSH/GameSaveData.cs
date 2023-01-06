using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSaveData : MonoBehaviour
{
    // PlayerPrefs에 저장
    public int maxScore = 0;

    void Start()
    {
        var obj = FindObjectsOfType<GameSaveData>();
        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadData()
    {
        if (PlayerPrefs.HasKey("maxScore"))
        {
            maxScore = PlayerPrefs.GetInt("maxScore");
        }
        else
        {
            PlayerPrefs.SetInt("maxScore", 0);
        }
    }

    public int GetMaxScore()
    {
        if (PlayerPrefs.HasKey("maxScore"))
        {
            return PlayerPrefs.GetInt("maxScore");
        }
        return 0;
    }

    public void SaveScore(int score)
    {
        maxScore = PlayerPrefs.GetInt("maxScore");
        if (score > maxScore)
        {
            Debug.Log("최고기록 갱신");
            PlayerPrefs.SetInt("maxScore", score);
        }
    }
}
