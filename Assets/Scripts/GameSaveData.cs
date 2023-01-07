using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSaveData : MonoBehaviour
{
    // PlayerPrefs에 저장
    // public int maxScore = 0;
    public int[] maxScore = new int[3];

    // singleton
    private static GameSaveData instance = null;
    public static GameSaveData Instance => instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void LoadData()
    {
        if (PlayerPrefs.HasKey("Data"))
        {
            // maxScore = PlayerPrefs.GetInt("maxScore");
            maxScore = GetArray();
            Debug.Log("LoadData에서 저장");
        }
        else
        {
            // PlayerPrefs.SetInt("maxScore", 0);
            PlayerPrefs.SetString("Data", "0,0,0");
        }
    }

    public int[] GetMaxScores()
    {
        int[] empty = new int[3];
        if (PlayerPrefs.HasKey("Data"))
        {
            //  return PlayerPrefs.GetInt("maxScore");
           int[] highest = GetArray();
            return highest;
        }
        return empty;
    }

    public void SaveScore(int score)
    {
        // maxScore = PlayerPrefs.GetInt("maxScore");
        maxScore = GetArray();

        /* if (score > maxScore)
         {
             Debug.Log("최고기록 갱신");
             PlayerPrefs.SetInt("maxScore", score);
         }*/
        if (maxScore[0] < score) // 1위보다 크면
        {
            Debug.Log("1위 최고기록 갱신");
            maxScore[2] = maxScore[1];
            maxScore[1] = maxScore[0];
            maxScore[0] = score;
        }
        else if (maxScore[1] < score)  // 2위보다 크면
        {
            Debug.Log("2위 최고기록 갱신");
            maxScore[2] = maxScore[1];
            maxScore[1] = score;
        }
        else if (maxScore[2] < score)
        {
            Debug.Log("3위 최고기록 갱신");
            maxScore[2] = score;
        }
        SaveArray(maxScore);
    }

    void SaveArray(int[] numArr)
    {
        string strArr = ""; 
        for (int i = 0; i < 3; i++) 
        {
            strArr = strArr + numArr[i];
            if (i < numArr.Length - 1) // 최대 길이의 -1까지만 ,를 저장
            {
                strArr = strArr + ",";
            }
        }
        PlayerPrefs.SetString("Data", strArr); // PlyerPrefs에 문자열 형태로 저장
    }

    int[] GetArray()
    {
        string[] strArr = PlayerPrefs.GetString("Data").Split(','); // PlayerPrefs에서 불러온 값을 Split 함수를 통해 문자열의 ,로 구분하여 배열에 저장
        Debug.Log(strArr);
        int[] maxScore = new int[strArr.Length]; // 문자열 배열의 크기만큼 정수형 배열 생성

        for (int i = 0; i < strArr.Length; i++)
        {
            maxScore[i] = System.Convert.ToInt32(strArr[i]); // 문자열 형태로 저장된 값을 정수형으로 변환후 저장
        }
        return maxScore;
    }
}
