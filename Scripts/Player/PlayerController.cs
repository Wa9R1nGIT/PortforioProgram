using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float jumpMultiplier = 1f; // ジャンプ力の乗数

    [SerializeField]
    private float fallMultiplier = 1f; // 落下速度の乗数

    private float groundY = -1f; // 地面のY座標
    private float maxJumpY = 4f; // 最大ジャンプ高さ
    private bool isGrounded = true; // プレイヤーが地面にいるかどうか
    private bool isFalling = false; // プレイヤーが下降中であるかどうか

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (transform.position.y >= maxJumpY && rb.velocity.y > 0)
        {
            StartFalling();
        }

        if (isFalling && transform.position.y <= groundY)
        {
            Land();
        }
    }

    void Jump()
    {
        float jumpForce =　jumpMultiplier;
        rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        isGrounded = false;
    }

    void StartFalling()
    {
        float fallSpeed = fallMultiplier;
        rb.velocity = new Vector3(rb.velocity.x, -fallSpeed, rb.velocity.z); // 上昇を止めて落下速度を設定
        isFalling = true;
        rb.useGravity = true; // 重力を使って下降させる
    }

    void Land()
    {
        isFalling = false;
        isGrounded = true; // プレイヤーが地面に着地したことを示す
        rb.useGravity = false;
        transform.position = new Vector3(transform.position.x, groundY, transform.position.z); // 正確に地面の高さに戻す
        rb.velocity = Vector3.zero; // 速度をリセット
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (transform.position.y <= groundY && isFalling)
        {
            Land();
        }
    }
}

