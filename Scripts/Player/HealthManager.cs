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
        UpdateHealthUI(); // ����������UI���X�V����
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("TakeDamage called. Damage: " + damage);
        healthPoint -= damage;
        healthPoint = Mathf.Clamp(healthPoint, 0, 3);
        UpdateHealthUI();

        if (healthPoint <= 0)
        {
            canvas1.gameObject.SetActive(false); // HP��0�ȉ��ɂȂ�����canvas1���\���ɂ���
            canvas2.gameObject.SetActive(true); // HP��0�ȉ��ɂȂ�����canvas2��\������
            Time.timeScale = 0f; // HP��0�ȉ��ɂȂ����玞�Ԃ��~����
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

