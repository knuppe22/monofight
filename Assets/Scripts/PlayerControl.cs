using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Debug.Log("in");
        Character player = GameManager.instance.Player;
        Transform playerTransform = player.transform;
        Rigidbody playerRigidbody = playerTransform.GetComponent<Rigidbody>();

        Character enemy = GameManager.instance.Enemy;
        Transform enemyTransform = enemy.transform;
        Rigidbody enemyRigidbody = enemyTransform.GetComponent<Rigidbody>();


        playerRigidbody.velocity = Vector3.zero;
        playerRigidbody.angularVelocity = Vector3.zero;
        enemyRigidbody.velocity = Vector3.zero;
        enemyRigidbody.angularVelocity = Vector3.zero;

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
        playerRigidbody.velocity = player.moveSpeed * moveDirection.normalized;
        //playerRigidbody.angularVelocity = Vector3.zero;
        //playerRigidbody.MovePosition(playerTransform.position + player.moveSpeed * Time.fixedDeltaTime * moveDirection.normalized);

        // TODO: rigidbody 떨리는 현상 고쳐야함
        enemyRigidbody.velocity = Vector3.zero;
        enemyRigidbody.angularVelocity = Vector3.zero;

    }
}
