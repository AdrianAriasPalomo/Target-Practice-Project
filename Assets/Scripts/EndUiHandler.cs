using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class EndUiHandler : MonoBehaviour
{

    // ABSTRACTION
    public void StartGame()
    {
        GameManager.Instance.score = 0;
        GameManager.Instance.timeRemaining = 30;
        SceneManager.LoadScene(1);
    }

    // ABSTRACTION
    public void GotoMenu()
    {
        SceneManager.LoadScene(0);
    }

    // ABSTRACTION
    public void Exit()
    {
        GameManager.Instance.SaveHighScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
