using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartScene : MonoBehaviour
{
    public TextMeshProUGUI score;
    int maxScore;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.Space))
        {
            SceneChange.Instance.OnLoadMainScene();
        }
    }
}