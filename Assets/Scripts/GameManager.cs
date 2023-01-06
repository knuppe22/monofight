using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // singleton
    public static GameManager instance = null;

    public Character[] characters;

    public int turn = 0;  // 0: 플레이어가 warrior, 1: 플레이어가 monster
    public float turnTime = 30.0f;
    public float currentTurnTime = 30.0f;
    public int score;

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

    void GameOver()
    {
        // TODO
    }
}
