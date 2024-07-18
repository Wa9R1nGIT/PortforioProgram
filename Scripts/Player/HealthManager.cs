using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public GameObject[] healthArray = new GameObject[3];
    public int healthPoint = 3;
    public string gameOverSceneName = "GameOver";
    public Camera secondCamera;
    public Canvas canvas1;
    public Canvas canvas2;

    void Start()
    {
        UpdateHealthUI(); // 初期化時にUIを更新する
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("TakeDamage called. Damage: " + damage);
        healthPoint -= damage;
        healthPoint = Mathf.Clamp(healthPoint, 0, 3);
        UpdateHealthUI();

        if (healthPoint <= 0)
        {
            canvas1.gameObject.SetActive(false); // HPが0以下になったらcanvas1を非表示にする
            canvas2.gameObject.SetActive(true); // HPが0以下になったらcanvas2を表示する
            Time.timeScale = 0f; // HPが0以下になったら時間を停止する
        }
    }

    void UpdateHealthUI()
    {
        for (int i = 0; i < healthArray.Length; i++)
        {
            healthArray[i].SetActive(i < healthPoint);
        }
    }
}

