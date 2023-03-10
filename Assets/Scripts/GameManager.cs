using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // singleton
    private static GameManager instance = null;
    public static GameManager Instance => instance;

    public Character[] characters;

    public int turn = 0;  // 0: 플레이어가 warrior, 1: 플레이어가 monster
    public float turnTime = 20.0f;
    public float currentTurnTime;
    public int score;

    public TextMeshProUGUI score_text;
    public GameObject gameOverPopup;

    public AddScore addscore;
    public WeaponIndicator wi;

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
    }

    private void Start()
    {
        currentTurnTime = turnTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTurnTime -= Time.deltaTime;

        if (currentTurnTime < 0 && Player.IsHitting <= 0 && Enemy.IsHitting <= 0)
        {
            turn = 1 - turn;
            currentTurnTime = turnTime;
            GetComponent<AI>().Rst = true;
        }
    }

    public void ScoreUp(int health)
    {
        int plus = 0;
        if (health >= 0 && health < 20)
        {
            plus = (int)((-0.5) * health + 40);
            score += plus;
            addscore.Use(plus);           // 이거 수정
        }
        else if (health < 50)
        {
            plus = (int)((-1 / 3) * (health - 20) + 30);
            score += plus;
            addscore.Use(plus);
        }
        else
        {
            plus = (int)((-0.2) * health + 30);
            score += plus;
            addscore.Use(plus);
        }
        score_text.text = "Score : " + score.ToString(); // UI에 점수 기록
    }

    public void GameOver()
    {
        Debug.Log("게임오버");
        gameOverPopup.SetActive(true);
    }
}
