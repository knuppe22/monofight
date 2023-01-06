using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // singleton
    private static GameManager instance = null;
    public static GameManager Instance => instance;

    public Character[] characters;

    public int turn = 0;  // 0: 플레이어가 warrior, 1: 플레이어가 monster
    public float turnTime = 30.0f;
    public float currentTurnTime = 30.0f;
    public int score;

    public GameObject gameOverPopup;

    public Character Player
    {
        get { return characters[turn]; }
    }
    public Character Enemy
    {
        get { return characters[1 - turn]; }
    }

    private void Awake()
    {
        // singleton
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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentTurnTime -= Time.deltaTime;

        if (currentTurnTime < 0)
        {
            turn = 1 - turn;
            currentTurnTime = turnTime;
        }
    }

    public void ScoreUp(int health)
    {
        int plus = 0;
        if (health >= 0 && health < 20)
        {
            plus = (int)((-0.5) * health + 40);
            score += plus;
        }
        else if (health < 50)
        {
            plus = (int)((-1 / 3) * (health - 20) + 30);
            score += plus;
        }
        else
        {
            plus = (int)((-0.2) * health + 30);
            score += plus;
        }
        // text.text = "Score : " + score.ToString(); // UI에 점수 기록
    }

    void GameOver()
    {
        Debug.Log("게임오버");
        gameOverPopup.SetActive(true);
    }
}
