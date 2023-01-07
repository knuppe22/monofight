using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddScore : MonoBehaviour
{
    public TextMeshProUGUI plusScore;
    // Start is called before the first frame update
    void Start()
    {
        plusScore.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Use(int num)
    {
        plusScore.text = $"+{num}";
        StopCoroutine("Addition");
        StartCoroutine("Addition");
    }

    IEnumerator Addition()
    {
        yield return new WaitForSeconds(0.01f);
        plusScore.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        plusScore.gameObject.SetActive(false);
    }
}
