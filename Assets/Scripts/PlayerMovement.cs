using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform playerHead;

    private Rigidbody rb;
    private Vector3 startMoveDir;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

    }

    public void Jump()
    {
        rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
    }

    public void Movement(Vector2 moveDir)
    {
        Vector3 camForward = playerHead.forward;
        Vector3 camRight = playerHead.right;
        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        // 입력에 따라 이동 방향 계산
        Vector3 MoveDir = camForward * moveDir.y + camRight * moveDir.x;

        MoveDir = Vector3.Lerp(startMoveDir, MoveDir, Time.deltaTime * 5);

        rb.velocity = new Vector3(MoveDir.x * 2, rb.velocity.y, MoveDir.z * 2);

        startMoveDir = MoveDir;
    }
}
