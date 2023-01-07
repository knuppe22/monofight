using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum AIState
{
    Idle,
    Trace,
    Attak,
    Die
}

public class AI : MonoBehaviour
{
    [SerializeField]
    private AIState state = AIState.Idle;
    [SerializeField]
    private float attackDistance;

    private Character player;
    private Character enemy;

    void Start()
    {
        for (int i = 0; i < GameManager.Instance.characters.Length; i++)
        {
            Character character = GameManager.Instance.characters[i];
            NavMeshAgent characterAgent = character.GetComponent<NavMeshAgent>();
            characterAgent.speed = character.moveSpeed;
            //characterAgent.stoppingDistance = attackDistance;
        }
    }

    void Update()
    {
        
    }

    void OnTraceEnter()
    {
        Character player = GameManager.Instance.Player;
        Character enemy = GameManager.Instance.Enemy;

        NavMeshAgent enemyNavmesh = enemy.GetComponent<NavMeshAgent>();
        NavMeshAgent playerNavmesh = player.GetComponent<NavMeshAgent>();

        Animator enemyAnimator = enemy.GetComponent<Animator>();
        enemy.IsWalking = true;

        enemyNavmesh.isStopped = false;
        playerNavmesh.isStopped = true;

        enemyNavmesh.destination = player.transform.position;

        StartCoroutine("OnTrace");
    }

    IEnumerator OnTrace()
    {
        if (true) // 거리가 얼마보다 크면
        {
            yield return null;
        }

        // 거리가 얼마 이하이면
        state = AIState.Attak;
        OnAttackEnter();
    }

    void OnAttackEnter()
    {
        enemy.StartAttack();
        StartCoroutine("OnAttack");
    }

    IEnumerator OnAttack()
    {
        if (enemy.IsHitting) // 공격중이면
        {
            yield return null;
        }

        state = AIState.Idle;
        OnTraceEnter();
    }
}
