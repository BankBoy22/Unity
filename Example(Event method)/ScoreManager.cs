using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;  // UI �ؽ�Ʈ
    private int score = 0;
    private float scoreIncreaseInterval = 1.0f;  // �� �ʸ��� ���ھ� ���� ����
    private float timeSinceLastIncrease = 0.0f;

    // Update is called once per frame
    void Update()
    {
        // ���� �ð����� ���ھ� ����
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
