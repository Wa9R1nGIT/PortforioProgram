using UnityEngine;
using TMPro;

public class ResultScreen : MonoBehaviour
{
    public TextMeshProUGUI resultScoreText; // ���U���g��ʂ̃X�R�A��\������TextMeshProUGUI
    public ScoreManager scoreManager; // ScoreManager�ւ̎Q��

    void Start()
    {
        if (scoreManager != null && resultScoreText != null)
        {
            resultScoreText.text = "�ŏI�X�R�A�I " + scoreManager.CurrentScore.ToString();
        }
    }
}