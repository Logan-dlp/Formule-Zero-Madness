using UnityEngine;

public class Boost : MonoBehaviour
{
    #region Settings
    [SerializeField] float forceAdd = 1000;
    [SerializeField] float timer = 3;
    
    [SerializeField] bool isCurrentboost;

    [SerializeField] GameObject boostEffect;
    [SerializeField] Drive player;
    [SerializeField] Camera playerCam;

    public static float CurrentTime;
    float baseSpeed;
    #endregion
    #region Meths
    void TimeBoost()
    {
        if (CurrentTime <= 0)
        {
            CurrentTime = 0;
            player.Speed = baseSpeed;
            isCurrentboost = false;
            boostEffect.SetActive(false);
        }
        else if (CurrentTime != 0 && isCurrentboost == true)
        {
            player.Speed = forceAdd;
            CurrentTime -= Time.deltaTime;
            boostEffect.SetActive(true);
        }
    }
    #endregion
    #region Meths Unity
    private void Start()
    {
        baseSpeed = player.Speed;
        boostEffect.SetActive(false);
    }
    private void Update()
    {
        TimeBoost();
    }
    private void OnTriggerEnter(Collider _collider)
    {
        if(_collider.gameObject.layer == player.LayerPlayer)
        {
            CurrentTime = timer;
            isCurrentboost = true;
            player.BoostSound.Play(0);
        }
    }
    #endregion
}
