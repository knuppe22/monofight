using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InGameUI : MonoBehaviour
{
    public Image[] hpImg; // hp 상태 이미지
    public TextMeshProUGUI[] hpText;

    public GameObject weapon_0;
    public GameObject weapon_1;
    public GameObject weapon_2;
    public GameObject weapon_3;

    public Image holdingWeapon_0;
    public Image holdingWeapon_1;
    public Image holdingWeapon_2;
    public Image holdingWeapon_3;

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
        if(weapon_0.activeSelf)
        {
            var Color0 = holdingWeapon_0.color;
            Color0.a = 0f;
            holdingWeapon_0.color = Color0;
            Color0.a = 0.75f;
            holdingWeapon_1.color = Color0;
            holdingWeapon_2.color = Color0;
            holdingWeapon_3.color = Color0;
        }
        else if(weapon_1.activeSelf)
        {
            var Color0 = holdingWeapon_0.color;
            Color0.a = 0f;
            holdingWeapon_1.color = Color0;
            Color0.a = 0.75f;
            holdingWeapon_0.color = Color0;
            holdingWeapon_2.color = Color0;
            holdingWeapon_3.color = Color0;
        }
        else if(weapon_2.activeSelf)
        {
            var Color0 = holdingWeapon_0.color;
            Color0.a = 0f;
            holdingWeapon_2.color = Color0;
            Color0.a = 0.75f;
            holdingWeapon_0.color = Color0;
            holdingWeapon_1.color = Color0;
            holdingWeapon_3.color = Color0;
        }
        else if(weapon_3.activeSelf)
        {
            var Color0 = holdingWeapon_0.color;
            Color0.a = 0f;
            holdingWeapon_3.color = Color0;
            Color0.a = 0.75f;
            holdingWeapon_0.color = Color0;
            holdingWeapon_1.color = Color0;
            holdingWeapon_2.color = Color0;
        }
        else
        {
            Debug.Log("not holding anything..?");
        }
    }


}
