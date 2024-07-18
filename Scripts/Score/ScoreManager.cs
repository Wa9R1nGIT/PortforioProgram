using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;  // TextMeshProのUIコンポーネント
    private int score = 0;  // スコアの初期値

    void Start()
    {
        // スコアを1秒ごとに増加させる
        InvokeRepeating("IncreaseScore", 1f, 1f);
    }

    void IncreaseScore()
    {
        score += 10;  // スコアを10増やす
        scoreText.text = "Score: " + score.ToString();  // スコアをUIに表示する
    }

    public void AddScore(int amount)
    {
        Debug.Log("AddScore called. Amount: " + amount); // デバッグログを追加
        score += amount;
        scoreText.text = "Score: " + score.ToString();
    }

    public int CurrentScore
    {
        get { return score; }
    }
}