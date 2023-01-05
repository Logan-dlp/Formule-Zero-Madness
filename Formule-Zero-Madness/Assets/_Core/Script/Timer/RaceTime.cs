using UnityEngine;
using UnityEngine.UI;

public class RaceTime : MonoBehaviour
{
    #region Settings
    [SerializeField] Text timerText;
    [SerializeField] StartTime startTime;

    public float MaxTime;
    #endregion
    #region Meths
    void Displaytime(float _timeToDisplay)
    {
        if (_timeToDisplay < 0)
        {
            _timeToDisplay = 0;
        }

        float _minutes = Mathf.FloorToInt(_timeToDisplay / 60);
        float _seconds = Mathf.FloorToInt(_timeToDisplay % 60);
        float _milliseconds = _timeToDisplay % 1 * 1000;

        timerText.text = string.Format("{0:00}:{1:00}:{2:000}", _minutes, _seconds, _milliseconds);
    }
    void Timer()
    {
        if(startTime.currentTime == 0)
        {
            if(MaxTime> 0)
            {
                MaxTime -= Time.deltaTime;
            }else
            {
                MaxTime = 0;
            }
        }
    }
    #endregion
    #region Meths Unity
    private void Update()
    {
        Timer();
        Displaytime(MaxTime);
    }
    #endregion
}
