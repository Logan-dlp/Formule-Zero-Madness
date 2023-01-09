using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] float addTime = 30;
    [SerializeField] Drive player;
    [SerializeField] RaceTime raceTime;
    private void OnTriggerEnter(Collider _collider)
    {
        if(_collider.gameObject.layer == player.LayerPlayer)
        {
            raceTime.MaxTime += addTime;
        }
    }
}
