using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // singleton
    private static PlayerControl instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameManager.Instance.Player.StartAttack();
        }
    }

    private void FixedUpdate()
    {
        Character player = GameManager.Instance.Player;
        Transform playerTransform = player.transform;
        Rigidbody playerRigidbody = playerTransform.GetComponent<Rigidbody>();

        Character enemy = GameManager.Instance.Enemy;
        Transform enemyTransform = enemy.transform;
        Rigidbody enemyRigidbody = enemyTransform.GetComponent<Rigidbody>();


        playerRigidbody.velocity = Vector3.zero;
        playerRigidbody.angularVelocity = Vector3.zero;
        enemyRigidbody.velocity = Vector3.zero;
        enemyRigidbody.angularVelocity = Vector3.zero;
        enemy.IsWalking = false; // TODO: 나중에 AI 추가후 바꿔야함

        if (player.IsHitting) return;

        // rotation
        // raycast
        // TODO: 맵 밖으로는 raycast 안됨, raycast용 안보이는 plane을 사용해야함
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        LayerMask layerMask = LayerMask.GetMask("Floor");
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            Vector3 newForward = hit.point - playerTransform.position;
            newForward.y = 0;
            playerTransform.rotation = Quaternion.LookRotation(newForward);
        }

        // move
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (moveDirection == Vector3.zero)
        {
            player.IsWalking = false;
        }
        else
        {
            moveDirection = moveDirection.normalized;
            player.IsWalking = true;
        }

        playerRigidbody.velocity = player.moveSpeed * moveDirection;
        //playerRigidbody.angularVelocity = Vector3.zero;
        //playerRigidbody.MovePosition(playerTransform.position + player.moveSpeed * Time.fixedDeltaTime * moveDirection.normalized);

        // TODO: rigidbody 떨리는 현상 고쳐야함
        enemyRigidbody.velocity = Vector3.zero;
        enemyRigidbody.angularVelocity = Vector3.zero;

    }
}
