using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // singleton
    public static GameManager instance = null;

    public int turn = 0;  // 0: �÷��̾ warrior, 1: �÷��̾ monster
    public float turnTime = 30.0f;
    public float currentTurnTime = 30.0f;
    public int score;

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
        if (currentTurnTime < 0)
        {
            turn = (turn + 1) % 2;
            currentTurnTime = turnTime;
        }
    }

    void GameOver()
    {
        // TODO
    }
}
