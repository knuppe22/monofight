using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timer;
    float currentTime;
    int timerTime;
    // Start is called before the first frame update
    private void Start()
    {
        currentTime = 30.0f;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = GameManager.Instance.currentTurnTime;
        timerTime = (int)currentTime; 
        if(timerTime <= 0)
        {
            timer.text = "<color=#e06666><b>Change!</b></color>";
        }
        else if(timerTime <= 5)
        {
            string a = timerTime.ToString();
            timer.text = $"<color=#e06666><b>{a}</b></color>";
        }
        else
        {
            timer.text = timerTime.ToString();
        }
    }
}
