using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataHandler : MonoBehaviour
{
    // Start and Update methods deleted, not needed.

    public static DataHandler Instance;

    public int highScore;
    public string highScorePlayer;

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
    }

    [System.Serializable]
    class SaveData
    {
        public int highScore;
        public string highScorePlayer;
        public List<TopScore> highScores;
    }

    public void SaveHighScores()
    {
        SaveData data = new SaveData();
        data.highScore = highScore;
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
            highScorePlayer = data.highScorePlayer;

            if (data.highScores != null)
            {
                topScores = data.highScores;
            }

        }
    }
}
