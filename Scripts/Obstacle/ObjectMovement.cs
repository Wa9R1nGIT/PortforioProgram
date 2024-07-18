using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float speed = 10f;

    public float minX = 9f; // ワープ可能な最小Z座標
    public float maxX = 14f; // ワープ可能な最大Z座標

    private void Start()
    {
        float randomX = Random.Range(minX, maxX);
        transform.position = new Vector3(randomX, transform.position.y, transform.position.z);
    }

    void Update()
    {
        // オブジェクトを前に移動させる
        transform.Translate(-Vector3.right * speed * Time.deltaTime);

        // オブジェクトがx座標 -14 に到達したら、ランダムなX座標にワープする
        if (transform.position.x <= -14f)
        {
            float randomX = Random.Range(minX, maxX);
            transform.position = new Vector3(randomX, transform.position.y, transform.position.z);
        }
    }
    private void OnBecameInvisible()
    {
        Debug.Log("OnBecameInvisible called");
        // オブジェクトが画面外に出たら、ランダムなX座標にワープする
        float randomX = Random.Range(minX, maxX);
        transform.position = new Vector3(randomX, transform.position.y, transform.position.z);
    }
}
