using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainUIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timeText;

    // Update is called once per frame
    void Update()
    {
        UpdateText();
    }

    void UpdateText()
    {
        string currentScore = GameManager.Instance.score.ToString();
        int roundedTime = (int)Mathf.Round(GameManager.Instance.timeRemaining);
        string currentTime = roundedTime.ToString();

        scoreText.text = currentScore;
        timeText.text = currentTime;
    }
}
