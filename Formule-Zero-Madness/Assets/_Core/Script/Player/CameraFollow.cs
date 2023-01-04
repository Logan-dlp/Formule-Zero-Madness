using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    #region Settings
    public float Smoothing;
    public Transform Player;
    #endregion
    #region Meths Unity
    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, Player.position, Smoothing);

        transform.rotation = Quaternion.Slerp(transform.rotation, Player.rotation, Smoothing);
        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
    }
    #endregion
}
