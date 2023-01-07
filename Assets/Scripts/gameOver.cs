using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOver : MonoBehaviour
{
    public GameObject gameOverPopup;
    public void GameOver()
    {
        Debug.Log("게임오버");
        gameOverPopup.SetActive(true);
    }
}
