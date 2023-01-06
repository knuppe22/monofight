using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private bool isWarrior {get;} // 전사인지, 몬스터인지 (inspector)
    public int CharacterID => isWarrior ? 0 : 1;
    
    private Weapon weapon;
    public Weapon Weapon {
        get => weapon;
        set {
            if(!isWarrior) return;
            weapon = value;
            // TODO: enable weapon GameObject
        }
    }

    public int Health {get; private set;} = 100;
    
    public void StartAttack()
    {
        // TODO: 애니메이션 시작
    }
    public void OnHit(int damage)
    {
        // TODO: 현재 체력에 맞춰 점수 획득
        Health -= damage;
    }
    public void DamageEnemy() {
        var enemy = GameManager.instance.characters[1 - CharacterID];
        enemy.OnHit(weapon.Damage);
    }
}
