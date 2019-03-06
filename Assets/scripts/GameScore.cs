using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{
    Text textScore;
    int score;
    public int Score
    {
        get
        {
            return this.score;
        }
        set
        {
            this.score = value;
            UpdateTextScore();
        }
    }

    // Use this for initialization
    void Start()
    {
        textScore = GetComponent<Text>();
    }

    void UpdateTextScore()
    {
        string scoreStr = string.Format("{0:000000}", score);
        textScore.text = scoreStr;
    }

} 