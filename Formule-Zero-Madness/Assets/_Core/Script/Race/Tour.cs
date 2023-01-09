using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tour : MonoBehaviour
{
    int tour = 0;
    [SerializeField] Drive player;
    [SerializeField] Text textTour;
    private void Update()
    {
        textTour.text = "Nombre de tour : " + tour.ToString("0");
    }
    private void OnTriggerEnter(Collider _collider)
    {
        if(_collider.gameObject.layer == player.LayerPlayer)
        {
            tour++;
        }
    }
}
