using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PlayerController playerController;
    public EnemyHealthManager enemyHealthManager;
    public HealthManager playerHealthManager;
    public CounterAttackManager counterAttackManager;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // ゲーム開始時の初期化処理
    }

    public void EnemyTakeDamage(int damage)
    {
        if (enemyHealthManager != null)
        {
            enemyHealthManager.EnemyTakeDamage(damage);
        }
    }

    public void InflictPlayerDamage(int damage)
    {
        if (playerHealthManager != null)
        {
            playerHealthManager.TakeDamage(damage);
        }
    }

    // 他のゲーム管理機能をここに追加
}