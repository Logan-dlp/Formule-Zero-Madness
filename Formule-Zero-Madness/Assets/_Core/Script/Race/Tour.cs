using UnityEngine;
using UnityEngine.UI;

public class Tour : MonoBehaviour
{
    #region Settings
    [SerializeField] Drive player;
    [SerializeField] Text textTour;

    public int tour = 0;
    #endregion
    #region Meths Unity
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
    #endregion
}
