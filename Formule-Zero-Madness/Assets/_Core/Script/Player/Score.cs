using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] Text displayScore;
    int score = 0;
    void GetScore()
    {
        score = PlayerPrefs.GetInt("Score", score);
        displayScore.text = score.ToString();
    }
    public void SetScore(int _tour)
    {
        score = _tour;
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
    }
    private void Update()
    {
        GetScore();
    }
}
