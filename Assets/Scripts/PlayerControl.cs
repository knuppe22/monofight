using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerControl : MonoBehaviour
{
    private Vector3 velocity;

    void Update()
    {
        if (Time.timeScale == 0.0f) return;

        Character player = GameManager.Instance.Player;
        Transform playerTransform = player.transform;

        velocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (velocity != Vector3.zero)
        {
            velocity = player.moveSpeed * velocity.normalized;
        }

        if (player.IsHitting >= 2) return;

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

        // attack
        if (Input.GetButtonDown("Fire1")&& (!EventSystem.current.IsPointerOverGameObject()))
        {
            player.StartAttack();
        }
    }

    private void FixedUpdate()
    {
        Character player = GameManager.Instance.Player;
        Rigidbody playerRigidbody = player.GetComponent<Rigidbody>();

        Character enemy = GameManager.Instance.Enemy;
        Rigidbody enemyRigidbody = enemy.GetComponent<Rigidbody>();

        if (player.IsHitting >= 2)
        {
            playerRigidbody.velocity = Vector3.zero;
            playerRigidbody.angularVelocity = Vector3.zero;
            return;
        }

        // move
        player.IsWalking = (velocity.magnitude > 0);

        playerRigidbody.velocity = velocity;
        //playerRigidbody.angularVelocity = Vector3.zero;
        //playerRigidbody.MovePosition(playerTransform.position + player.moveSpeed * Time.fixedDeltaTime * moveDirection.normalized);

        // TODO: rigidbody 떨리는 현상 고쳐야함
        enemyRigidbody.velocity = Vector3.zero;
        enemyRigidbody.angularVelocity = Vector3.zero;

    }
}
