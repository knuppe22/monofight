using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum AIState
{
    Idle,
    Trace,
    Attack,
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
    [HideInInspector]
    public bool Rst = false;

    void Start()
    {
        for (int i = 0; i < GameManager.Instance.characters.Length; i++)
        {
            Character character = GameManager.Instance.characters[i];
            NavMeshAgent characterAgent = character.GetComponent<NavMeshAgent>();
            characterAgent.speed = character.moveSpeed;
            //characterAgent.stoppingDistance = attackDistance;
        }
        OnReset();
    }

    public void OnReset()
    {
        Debug.Log("OnReset");
        state = AIState.Idle;
        Rst = false;
        OnTraceEnter();
    }

    void OnTraceEnter()
    {
        player = GameManager.Instance.Player;
        enemy = GameManager.Instance.Enemy;

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
        NavMeshAgent enemyNavmesh = enemy.GetComponent<NavMeshAgent>();
        while (!Rst && (player.transform.position - enemy.transform.position).sqrMagnitude > attackDistance) // 거리가 얼마보다 크면
        {
            enemyNavmesh.destination = player.transform.position;
            yield return null;
        }
        if (Rst) OnReset();

        enemyNavmesh.isStopped = true;

        // 거리가 얼마 이하이면
        state = AIState.Attack;
        OnAttackEnter();
    }

    void OnAttackEnter()
    {
        enemy.StartAttack();
        enemy.SetIsHitting(1);
        StartCoroutine("OnAttack");
    }

    IEnumerator OnAttack()
    {
        while (!Rst && enemy.IsHitting >= 1) // 공격중이면
        {
            yield return null;
        }
        if (Rst) OnReset();

        state = AIState.Idle;
        OnTraceEnter();
    }
}
