using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boost : MonoBehaviour
{
    [SerializeField] float forceAdd = 1000;
    [SerializeField] float timer = 3;
    [SerializeField] Drive player;
    float baseSpeed;
    public static float CurrentTime;
    [SerializeField] bool isCurrentboost;
    
    void TimeBoost()
    {
        if (CurrentTime <= 0)
        {
            CurrentTime = 0;
            player.Speed = baseSpeed;
            isCurrentboost = false;
        }
        else if (CurrentTime != 0 && isCurrentboost == true)
        {
            player.Speed = forceAdd;
            CurrentTime -= Time.deltaTime;
        }
    }
    private void Start()
    {
        baseSpeed = player.Speed;
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
        }
    }
}
