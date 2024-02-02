using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class UI_Menu_Manager : MonoBehaviour
{
    public InputField nameField;
    public static string playerName;
    public TextMeshProUGUI bestScoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        bestScoreText.text = "Best Score: " + DataHandler.Instance.highScorePlayer + ": " + DataHandler.Instance.highScore;
    }

    public void StartNew()
    {
        playerName = nameField.text;
        SceneManager.LoadScene(1);
    }

    public void GoToLeaderBoard()
    {
        SceneManager.LoadScene(2);
    }

    public void GoToSettings()
    {
        SceneManager.LoadScene(3);
    }

    public void ResetScores()
    {
        DataHandler.Instance.highScorePlayer = null;
        DataHandler.Instance.highScore = 0;
        DataHandler.topScores.Clear();
    }

    public void Exit()
    {
        DataHandler.Instance.SaveHighScores();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

}
