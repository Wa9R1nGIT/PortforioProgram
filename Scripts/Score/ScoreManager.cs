using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;  // TextMeshPro��UI�R���|�[�l���g
    private int score = 0;  // �X�R�A�̏����l

    void Start()
    {
        // �X�R�A��1�b���Ƃɑ���������
        InvokeRepeating("IncreaseScore", 1f, 1f);
    }

    void IncreaseScore()
    {
        score += 10;  // �X�R�A��10���₷
        scoreText.text = "Score: " + score.ToString();  // �X�R�A��UI�ɕ\������
    }

    public void AddScore(int amount)
    {
        Debug.Log("AddScore called. Amount: " + amount); // �f�o�b�O���O��ǉ�
        score += amount;
        scoreText.text = "Score: " + score.ToString();
    }

    public int CurrentScore
    {
        get { return score; }
    }
}