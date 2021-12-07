using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainUIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private TextMeshProUGUI timeText;

    // Update is called once per frame
    void Update()
    {
        UpdateText();
    }

    // ABSTRACTION
    void UpdateText()
    {
        string currentScore = GameManager.Instance.score.ToString();
        string currentHighScore = GameManager.Instance.highScore.ToString();
        
        scoreText.text = currentScore;
        highScoreText.text = currentHighScore;

        if (SceneManager.GetActiveScene().name == "Main")
        {
            int roundedTime = (int)Mathf.Round(GameManager.Instance.timeRemaining);
            string currentTime = roundedTime.ToString();
            timeText.text = currentTime;
        }
    }
}
