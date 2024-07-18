using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public GameObject[] EhealthArray = new GameObject[3];
    public int EhealthPoint = 3;
    private int currentLives;
    private bool isBossSummoned;
    public ScoreManager scoreManager; // ScoreManagerへの参照を追加

    void Start()
    {
        UpdateEnemyHealthUI(); // 初期化時にUIを更新する
    }

    public void EnemyTakeDamage(int damage)
    {
        Debug.Log("TakeDamage called. Damage: " + damage);
        EhealthPoint -= damage;
        if (EhealthPoint <= 0)
        {
            transform.position = new Vector3(13f, transform.position.y, transform.position.z);
            EhealthPoint = 3;
            EnemyMovement enemyMovement = GetComponent<EnemyMovement>();
            if (enemyMovement != null)
            {
                enemyMovement.speed = 2f;
            }
            currentLives++;
            if (currentLives >= 3)
            {
                SummonBoss();
                EhealthPoint = 10; // ボスの時はHPを10にする
            }
            else
            {
                RespawnEnemy();
                scoreManager.AddScore(100); // 敵が死んだ時にスコアを100加算
            }
        }
        EhealthPoint = Mathf.Clamp(EhealthPoint, 0, 3);
        UpdateEnemyHealthUI();
    }

    void UpdateEnemyHealthUI()
    {
        for (int i = 0; i < EhealthArray.Length; i++)
        {
            EhealthArray[i].SetActive(i < EhealthPoint);
        }
    }

    void SummonBoss()
    {
        isBossSummoned = true;
    }

    void RespawnEnemy()
    {
        isBossSummoned = false;
    }
}
