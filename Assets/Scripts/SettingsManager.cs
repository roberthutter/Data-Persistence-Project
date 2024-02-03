using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{

    public Dropdown dropDown;
    public int dValue;

    void Start()
    {
        dropDown.value = DataHandler.Instance.setValue;
    }

    public void GetDifficulty()
    {
        dValue = dropDown.value;
        DataHandler.Instance.setValue = dValue;
        DataHandler.Instance.SetDifficulty(dValue);
    }

    public void BacktoMenu()
    {
        SceneManager.LoadScene(0);
    }
}
