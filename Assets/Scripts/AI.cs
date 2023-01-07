using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    void Update()
    {
        Transform enemy = GameManager.Instance.Enemy.transform;
        Transform player = GameManager.Instance.Player.transform;

        NavMeshAgent enemyNavmesh = enemy.GetComponent<NavMeshAgent>();
        NavMeshAgent playerNavmesh = player.GetComponent<NavMeshAgent>();

        Animator enemyAnimator = enemy.GetComponent<Animator>();
        enemyAnimator.SetBool("IsWalking", true);

        enemyNavmesh.isStopped = false;
        playerNavmesh.isStopped = true;

        enemyNavmesh.destination = player.position;
    }
}
