using UnityEngine;
using TMPro;

public class ResultScreen : MonoBehaviour
{
    public TextMeshProUGUI resultScoreText; // リザルト画面のスコアを表示するTextMeshProUGUI
    public ScoreManager scoreManager; // ScoreManagerへの参照

    void Start()
    {
        if (scoreManager != null && resultScoreText != null)
        {
            resultScoreText.text = "最終スコア！ " + scoreManager.CurrentScore.ToString();
        }
    }
}