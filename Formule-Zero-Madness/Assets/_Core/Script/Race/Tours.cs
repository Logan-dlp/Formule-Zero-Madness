using UnityEngine;
using UnityEngine.UI;

public class Tours : MonoBehaviour
{
    #region Settings
    [SerializeField] Drive player;
    [SerializeField] Text textTour;

    public int Tour = 0;
    #endregion
    #region Meths Unity
    private void Update()
    {
        textTour.text = "Nombre de tour : " + Tour.ToString("0");
    }
    private void OnTriggerEnter(Collider _collider)
    {
        if(_collider.gameObject.layer == player.LayerPlayer)
        {
            Tour++;
        }
    }
    #endregion
}
