using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    #region Settings
    [Header("Display")]
    [SerializeField] Text displayScore;

    [HideInInspector] public int score = 0;
    #endregion
    #region Meths
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
    #endregion
    #region Meths Unity
    private void Update()
    {
        GetScore();
    }
    #endregion
}
