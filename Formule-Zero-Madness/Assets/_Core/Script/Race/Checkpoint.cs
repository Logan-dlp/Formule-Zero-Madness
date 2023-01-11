using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    #region Settings
    [SerializeField] float addTime = 30;
    [SerializeField] Drive player;
    [SerializeField] RaceTime raceTime;
    [SerializeField] SecureCheckpoint checkpoint;
    #endregion
    #region Meths Unity
    private void OnTriggerEnter(Collider _collider)
    {
        if(_collider.gameObject.layer == player.LayerPlayer)
        {
            raceTime.MaxTime += addTime;
            checkpoint.NumberOfCheckpoint++;
        }
    }
    #endregion
}
