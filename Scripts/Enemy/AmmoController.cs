using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoController : MonoBehaviour
{
    public float speed = 5.0f;
    private int damage = 1;

    void Update()
    {
        GameObject enemy = FindClosestEnemy();
        if (enemy != null)
        {
            Vector3 direction = enemy.transform.position - transform.position;
            transform.position += direction.normalized * speed * Time.deltaTime;
        }
    }

    GameObject FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject enemy in enemies)
        {
            Vector3 diff = enemy.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = enemy;
                distance = curDistance;
            }
        }
        return closest;
    }
    private void OnTriggerEnter(Collider other)
    {
        // “G‚É“–‚½‚Á‚½ê‡
        Debug.Log("ammo hit enemy");
        if (other.CompareTag("Enemy"))
        {
            EnemyTakeDamage(damage);
            Destroy(gameObject);
        }
    }

    private void EnemyTakeDamage(int damage)
    {
        EnemyHealthManager enemyHealth = FindObjectOfType<EnemyHealthManager>();
        if (enemyHealth != null)
        {
            enemyHealth.EnemyTakeDamage(damage);
        }
    }
}