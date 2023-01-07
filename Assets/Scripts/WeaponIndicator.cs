using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WeaponIndicator : MonoBehaviour
{
    private int durability = 10;
    public int Durability {
        get => durability;
        set {
            durability = value;
            DurabilityText.text = $"{durability}";
        }
    }
    [SerializeField]
    private TextMeshProUGUI DurabilityText;
    [SerializeField]
    private Sprite[] weaponImages;
    [SerializeField]
    private Image indicatorImage;
    private int weaponIndex = 0;
    public int WeaponIndex {
        get => weaponIndex;
        set {
            weaponIndex = value;
            indicatorImage.sprite = weaponImages[value];
        }
    }
}
