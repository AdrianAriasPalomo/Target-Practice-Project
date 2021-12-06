using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
    }
}
