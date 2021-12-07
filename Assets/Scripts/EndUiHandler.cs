using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class EndUiHandler : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.Instance.score = 0;
        GameManager.Instance.timeRemaining = 30;
        SceneManager.LoadScene(1);
    }

    public void GotoMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
