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
    
    private Weapon weapon = new Fist();
    public Weapon Weapon {
        get => weapon;
        set {
            if(!isWarrior) return;
            weapon = value;
            // TODO: enable weapon GameObject
        }
    }

    public int Health {get; private set;} = 100;
    private bool isWalking = false;
    public bool IsWalking {
        get => isWalking;
        set {
            isWalking = value;
            animator.SetBool("IsWalking",value);
        }
    }

    private void Awake() 
    {
        animator = GetComponent<Animator>();
    }
    [ContextMenu("공격")]
    public void StartAttack()
    {
        animator.SetTrigger("Attack");
    }

    // 피격당했을 때
    public void OnHit(int damage)
    {
        if (CharacterID != GameManager.instance.turn) { // 플레이어가 때린 거면
            // 현재 체력에 맞춰 점수 획득
            GameManager.instance.ScoreUp(Health);
        }
        Health -= damage;
    }

    // 적 타격하는 시점에서 호출되는 함수
    public void DamageEnemy() 
    {
        var enemy = GameManager.instance.characters[1 - CharacterID];
        // TODO: 거리 계산해서 피격 판정
        enemy.OnHit(weapon.Damage);
    }
    [ContextMenu("걷기 토글")]
    public void ToggleIsWalking() 
    {
        IsWalking = !IsWalking;
    }
    
}
