using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class DataHandler : MonoBehaviour
{
    // Start and Update methods deleted, not needed.

    public static DataHandler Instance;

    public int highScore;
    public string highScorePlayer;
    public int setValue;
    public float ballAccel;
    public float maxballSpeed;

    [System.Serializable]
    public class TopScore
    {
        public int highscore;
        public string highScorePlayer;
    }

    public static List<TopScore> topScores = new List<TopScore>();

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
        SetDifficulty(setValue);
    }

    [System.Serializable]
    class SaveData
    {
        public int highScore;
        public int setValue;
        public string highScorePlayer;
        public List<TopScore> highScores;
    }

    public void SaveHighScores()
    {
        SaveData data = new SaveData();
        data.highScore = highScore;
        data.setValue = setValue;
        data.highScorePlayer = highScorePlayer;
        data.highScores = topScores;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            setValue = data.setValue;
            highScorePlayer = data.highScorePlayer;

            if (data.highScores != null)
            {
                topScores = data.highScores;
            }

        }
    }

    public void SetDifficulty(int sValue)
    {
        if (sValue == 0)
        {
            ballAccel = 0.01f;
            maxballSpeed = 3.0f;
        }
        else if (sValue == 1)
        {
            ballAccel = 0.02f;
            maxballSpeed = 4.0f;
        }
        else if (sValue == 2)
        {
            ballAccel = 0.03f;
            maxballSpeed = 5.0f;
        }
    }
}
