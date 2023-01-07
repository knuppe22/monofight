using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InGameUI : MonoBehaviour
{
    public Image[] hpImg; // hp 상태 이미지
    public TextMeshProUGUI[] hpText;

    public Image[] holdingWeapons;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < GameManager.Instance.characters.Length; i++)
        {
            Character character = GameManager.Instance.characters[i];
            // 체력 0~1 UI에 표시
            hpImg[i].fillAmount = (float)(character.Health * 0.01);
            if (character.Health > 0)
                hpText[i].text = "(" + character.Health.ToString() + "/100)";
            else // 게임오버
            {
                hpText[i].text = "(0/100)";
                GameManager.Instance.GameOver();
            }
        }
        ChangeHaveWeaponUI();
    }

    void ChangeHaveWeaponUI()
    {
        for (int i = 0; i < holdingWeapons.Length; i++)
        {
            Color color = holdingWeapons[i].color;

            if (i == GameManager.Instance.characters[0].WeaponIndex)
                color.a = 0.0f;
            else
                color.a = 0.75f;
            holdingWeapons[i].color = color;
        }
    }


}
