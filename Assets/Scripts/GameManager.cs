using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public float timeRemaining = 30;

    // ENCAPSULATION
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

    // ENCAPTULATION
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
        LoadHighScore();
    }

    private void Update()
    {
        ManageTimer();
    }

    // ABSTRACTION
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

    // Implement data persistence between sessions
    [System.Serializable]
    class SaveData
    {
        public int highScore;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
        }
    }
}
