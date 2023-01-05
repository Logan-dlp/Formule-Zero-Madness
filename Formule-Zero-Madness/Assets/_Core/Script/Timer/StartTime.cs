using UnityEngine;
using UnityEngine.UI;

public class StartTime : MonoBehaviour
{
    #region Settings
    [SerializeField] float StartingTime = 3;
    [SerializeField] Text timeText;
    [SerializeField] GameObject uI;

    public float currentTime = 0;
    #endregion
    #region Meths
    void SetTime()
    {
        uI.SetActive(true);
        currentTime = StartingTime;
    }
    void Timer()
    {
        currentTime -= 1 * Time.deltaTime;
        timeText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            uI.SetActive(false);
            currentTime = 0;
        }
    }
    #endregion
    #region Meths Unity
    private void Start()
    {
        SetTime();
    }
    private void Update()
    {
        Timer();
    }
    #endregion
}
