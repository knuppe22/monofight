using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Character : MonoBehaviour
{
    private Animator animator;
    [SerializeField]
    private bool isWarrior; // 전사인지, 몬스터인지 (inspector)
    public int CharacterID => isWarrior ? 0 : 1;
    private Character enemy;

    public float moveSpeed;

    public Weapon[] WeaponList; // 모든 weapon instance의 리스트 (inspector), 기본 무기는 0
    private int weaponIndex;
    public int WeaponIndex
    {
        get => weaponIndex;
        set
        {
            if (!isWarrior || (0 > value && value > WeaponList.Length)) return;
            WeaponList[weaponIndex].gameObject.SetActive(false);
            WeaponList[value].gameObject.SetActive(true);
            weaponIndex = value;
        }
    }
    private Weapon weapon => WeaponList[weaponIndex];
    public int IsHitting { get; private set; }
    [HideInInspector]
    public bool enableHit = false; // 한 번 공격에 한 번만 맞게 하기 위해 설정하는 flag

    public int Health { get; private set; } = 100;

    private bool isWalking = false;
    public bool IsWalking
    {
        get => isWalking;
        set
        {
            isWalking = value;
            animator.SetBool("IsWalking", value);
        }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        enemy = GameManager.Instance.characters[1 - CharacterID];

        WeaponList[0].gameObject.SetActive(true);
        for (int i = 1; i < WeaponList.Length; i++)
            WeaponList[i].gameObject.SetActive(false);
    }

    private void Update()
    {
    }

    [ContextMenu("공격")]
    public void StartAttack()
    {
        if (/*CharacterID != GameManager.Instance.turn ||*/ IsHitting >= 2) return;
        transform.LookAt(enemy.transform);
        animator.SetTrigger("Attack");
    }

    // 피격당했을 때
    public void OnHit(int damage)
    {
        if (!enableHit) return;
        enableHit = false; // 타격 비활성화

        Debug.Log((CharacterID == GameManager.Instance.turn ? "Player" : "Enemy") + $" Damage! {damage}");
        if (CharacterID != GameManager.Instance.turn) // 플레이어가 때린 거면
        {
            // 현재 체력에 맞춰 점수 획득
            GameManager.Instance.ScoreUp(Health);
        }
        Health -= damage;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Weapon")
        {
            OnHit(enemy.weapon.Damage); // 적 타격
        }
        else if (
            other.tag == "DropItems" &&
            CharacterID == GameManager.Instance.turn &&
            CharacterID == 0
            )
        {
            WeaponIndex = other.GetComponent<DropItems>().id;
            Destroy(other.gameObject);
        }
    }
    [ContextMenu("걷기 토글")]
    public void ToggleIsWalking()
    {
        IsWalking = !IsWalking;
    }
    public void SetIsHitting(int v)
    {
        IsHitting = v;
        weapon.GetComponent<Collider>().enabled = v >= 2;
        enemy.enableHit = v >= 2;

        if (v <= 0 && WeaponIndex != 0) // 공격이 끝나는 시점
        {
            bool isBroken = weapon.OnAttack();
            if (isBroken) // 무기 내구도가 다하면 기본무기로 전환
                WeaponIndex = 0;
        }
    }
}
