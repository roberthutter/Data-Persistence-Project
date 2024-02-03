using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public Text bestScoreText;
    public GameObject GameOverText;
    
    private bool m_Started = false;
    private int m_Points;
    private DataHandler.TopScore newTopScore = new DataHandler.TopScore();
    
    private bool m_GameOver = false;

    
    // Start is called before the first frame update
    void Start()
    {
        bestScoreText.text = "Best Score : " + DataHandler.Instance.highScorePlayer + ": " + DataHandler.Instance.highScore;

        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        
        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = "Score : " + UI_Menu_Manager.playerName + ": " + m_Points;
        if (m_Points > DataHandler.Instance.highScore)
        {
            DataHandler.Instance.highScore = m_Points;
            DataHandler.Instance.highScorePlayer = UI_Menu_Manager.playerName;
            newTopScore.highscore = m_Points;
            newTopScore.highScorePlayer = UI_Menu_Manager.playerName;

        }
    }

    public void GameOver()
    {
        bestScoreText.text = "Best Score : " + DataHandler.Instance.highScorePlayer + ": " + DataHandler.Instance.highScore;
        if (newTopScore.highscore > 0)
        {
            DataHandler.topScores.Add(newTopScore);
            if (DataHandler.topScores.Count > 5)
            {
                DataHandler.topScores.RemoveAt(0);
            }
        }
        m_GameOver = true;
        GameOverText.SetActive(true);
    }

    public void BacktoMenu()
    {
        SceneManager.LoadScene(0);
    }
}
