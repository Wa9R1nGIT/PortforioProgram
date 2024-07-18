using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDamage : MonoBehaviour
{
    public int damage = 1; // 敵の攻撃力

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {

            HealthManager playerHealth = collision.gameObject.GetComponent<HealthManager>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage); // プレイヤーにダメージを与える
            }
        }
    }
}
