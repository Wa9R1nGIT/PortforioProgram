using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CounterAttackManager : MonoBehaviour
{
    public TMP_Text counterKeyText;  // ランダムなキーを表示する
    public TMP_Text timerText;  // 攻撃までの時間を表示する
    public TMP_Text attackText;

    public int damage = 1;  // プレイヤーに与えるダメージ

    public GameObject ammoPrefab;  // Amoのプレハブ
    public Transform ammoSpawnPoint;  // Amoの生成位置

    private string[] counterKeys = { "A", "B", "C", "D", "E",
                                     "F", "G", "H", "I", "J",
                                     "K", "L", "M", "N", "O",
                                     "P", "Q", "R", "S", "T",
                                     "U", "V", "W", "X", "Y",
                                     "X", "1", "2", "3", "4",
                                     "5", "6", "7", "8", "9",
                                    };

    private string currentCounterKey;
    private bool isCounterActive = false;
    private float counterWindow = 5f;  // カウンターの猶予時間
    private float timeRemaining;
    private Coroutine enemyAttackCoroutine;  // 現在のコルーチンを管理するための変数

    void Start()
    {
        counterKeyText.text = "";
        timerText.text = "";
        StartEnemyAttack();  // ゲーム開始時に敵の攻撃を開始
    }

    // 敵の攻撃を開始する関数
    public void StartEnemyAttack()
    {
        // 既存のコルーチンが実行中であれば停止する
        if (enemyAttackCoroutine != null)
        {
            StopCoroutine(enemyAttackCoroutine);
        }
        enemyAttackCoroutine = StartCoroutine(EnemyAttackCoroutine());
    }

    private IEnumerator EnemyAttackCoroutine()
    {
        // ランダムなキーを選んで表示
        currentCounterKey = counterKeys[Random.Range(0, counterKeys.Length)];
        counterKeyText.text = currentCounterKey;
        isCounterActive = true;
        timeRemaining = counterWindow;

        while (timeRemaining > 0)
        {
            timerText.text = "EnemyAttackTime: " + timeRemaining.ToString("F2") + " s";
            yield return new WaitForSeconds(0.1f);
            timeRemaining -= 0.1f;
        }

        // カウンターが成功しなかった場合
        if (isCounterActive)
        {
            InflictPlayerDamage(damage);

            // カウンターキーの表示をクリア
            counterKeyText.text = "";
            timerText.text = "";
            isCounterActive = false;
            // 再度敵の攻撃を開始
            StartEnemyAttack();
        }
    }

    void Update()
    {
        if (isCounterActive)
        {
            // プレイヤーが正しいキーを押したかチェック
            if (Input.GetKeyDown(currentCounterKey.ToLower()))
            {
                Debug.Log("カウンター成功!");
                Instantiate(ammoPrefab, ammoSpawnPoint.position, ammoSpawnPoint.rotation);
                isCounterActive = false;
                counterKeyText.text = "";
                timerText.text = "";
                // 再度敵の攻撃を開始して時間をリセット
                StartEnemyAttack();
            }
            else if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("カウンター失敗!");
                InflictPlayerDamage(damage);

                // カウンターキーの表示をクリア
                counterKeyText.text = "";
                timerText.text = "";
                isCounterActive = false;
                // 再度敵の攻撃を開始
                StartEnemyAttack();
            }
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

    private void InflictPlayerDamage(int damage)
    {
        HealthManager playerHealth = FindObjectOfType<HealthManager>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
