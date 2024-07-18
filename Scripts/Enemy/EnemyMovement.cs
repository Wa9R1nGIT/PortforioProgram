using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        
        // オブジェクトを前に移動させる
        transform.Translate(-Vector3.right * speed * Time.deltaTime);

        if (transform.position.x < 6)
        {
            speed = 0;
        }
    }
}
