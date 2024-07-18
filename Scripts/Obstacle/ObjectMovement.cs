using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float speed = 10f;

    public float minX = 9f; // ���[�v�\�ȍŏ�Z���W
    public float maxX = 14f; // ���[�v�\�ȍő�Z���W

    private void Start()
    {
        float randomX = Random.Range(minX, maxX);
        transform.position = new Vector3(randomX, transform.position.y, transform.position.z);
    }

    void Update()
    {
        // �I�u�W�F�N�g��O�Ɉړ�������
        transform.Translate(-Vector3.right * speed * Time.deltaTime);

        // �I�u�W�F�N�g��x���W -14 �ɓ��B������A�����_����X���W�Ƀ��[�v����
        if (transform.position.x <= -14f)
        {
            float randomX = Random.Range(minX, maxX);
            transform.position = new Vector3(randomX, transform.position.y, transform.position.z);
        }
    }
    private void OnBecameInvisible()
    {
        Debug.Log("OnBecameInvisible called");
        // �I�u�W�F�N�g����ʊO�ɏo����A�����_����X���W�Ƀ��[�v����
        float randomX = Random.Range(minX, maxX);
        transform.position = new Vector3(randomX, transform.position.y, transform.position.z);
    }
}
