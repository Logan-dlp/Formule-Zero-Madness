using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    #region Settings
    [SerializeField] float smoothing;
    [SerializeField] Transform player;
    #endregion
    #region Meths Unity
    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.position, smoothing);

        transform.rotation = Quaternion.Slerp(transform.rotation, player.rotation, smoothing);
        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
    }
    #endregion
}
