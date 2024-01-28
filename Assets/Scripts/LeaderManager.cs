using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LeaderManager : MonoBehaviour
{
    public Text[] leaders = new Text[5];

    private int count;
    private int listIndex;

    private List<DataHandler.TopScore> highScores;

    
    // Start is called before the first frame update
    void Start()
    {
        if (DataHandler.topScores != null)
        {
            highScores = DataHandler.topScores;
            count = highScores.Count;
            listIndex = count - 1;
            for (int i = 0; i < count; i++)
            {
                leaders[i].text = (i + 1) + ": " + highScores[listIndex].highScorePlayer + ": " + highScores[listIndex].highscore;
                listIndex -= 1;
            }
        }

    }

    public void BacktoMenu()
    {
        SceneManager.LoadScene(0);
    }

}
