using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;  // UI 텍스트
    private int score = 0;
    private float scoreIncreaseInterval = 1.0f;  // 매 초마다 스코어 증가 간격
    private float timeSinceLastIncrease = 0.0f;

    // Update is called once per frame
    void Update()
    {
        // 일정 시간마다 스코어 증가
        timeSinceLastIncrease += Time.deltaTime;
        if (timeSinceLastIncrease >= scoreIncreaseInterval)
        {
            IncreaseScore(10);
            timeSinceLastIncrease = 0.0f;
        }
    }

    void IncreaseScore(int amount)
    {
        score += amount;
        scoreText.text = "Score : " + score.ToString();
    }
}
