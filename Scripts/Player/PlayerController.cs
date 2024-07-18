using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float jumpMultiplier = 1f; // �W�����v�͂̏搔

    [SerializeField]
    private float fallMultiplier = 1f; // �������x�̏搔

    private float groundY = -1f; // �n�ʂ�Y���W
    private float maxJumpY = 4f; // �ő�W�����v����
    private bool isGrounded = true; // �v���C���[���n�ʂɂ��邩�ǂ���
    private bool isFalling = false; // �v���C���[�����~���ł��邩�ǂ���

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
        float jumpForce =�@jumpMultiplier;
        rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        isGrounded = false;
    }

    void StartFalling()
    {
        float fallSpeed = fallMultiplier;
        rb.velocity = new Vector3(rb.velocity.x, -fallSpeed, rb.velocity.z); // �㏸���~�߂ė������x��ݒ�
        isFalling = true;
        rb.useGravity = true; // �d�͂��g���ĉ��~������
    }

    void Land()
    {
        isFalling = false;
        isGrounded = true; // �v���C���[���n�ʂɒ��n�������Ƃ�����
        rb.useGravity = false;
        transform.position = new Vector3(transform.position.x, groundY, transform.position.z); // ���m�ɒn�ʂ̍����ɖ߂�
        rb.velocity = Vector3.zero; // ���x�����Z�b�g
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (transform.position.y <= groundY && isFalling)
        {
            Land();
        }
    }
}

