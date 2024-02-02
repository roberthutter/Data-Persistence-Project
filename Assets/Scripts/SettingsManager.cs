using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{

    public Dropdown dropDown;

    public static float ballAccel;
    public static float maxballSpeed;

    public void SetDifficulty()
    {
        if (dropDown.value == 0)
        {
            ballAccel = 0.01f;
            maxballSpeed = 3.0f;
        }
        else if (dropDown.value == 1)
        {
            ballAccel = 0.02f;
            maxballSpeed = 4.0f;
        }
        else if (dropDown.value == 2)
        {
            ballAccel = 0.03f;
            maxballSpeed = 5.0f;
        }
    }

    public void BacktoMenu()
    {
        SceneManager.LoadScene(0);
    }
}
