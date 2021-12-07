using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public float timeRemaining = 30;

    private int m_score = 0;

    public int score
    {
        get { return m_score; }
        set
        {
            if (value < 0.0f)
            {
                Debug.LogError("Score can't be negative");
            }
            else
            {
                m_score = value;
            }
        }
    }

    private int m_highScore;

    public int highScore
    {
        get { return m_highScore; }
        set
        {
            if (value < score)
            {
                Debug.LogError("High score can't be smaller than score");
            }
            else
            {
                m_highScore = value;
            }
        }
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        ManageTimer();
    }

    private void ManageTimer()
    {
        if (timeRemaining > 0 && SceneManager.GetActiveScene().name == "Main")
        {
            timeRemaining -= Time.deltaTime;
        }
        else if (timeRemaining <= 0)
        {
            timeRemaining = 30;
            SceneManager.LoadScene(2);
        }
    }
}
