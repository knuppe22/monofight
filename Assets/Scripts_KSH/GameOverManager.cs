using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPopup;

    public void gameOver()
    {
        Debug.Log("게임오버");
        gameOverPopup.SetActive(true);
    }
}
