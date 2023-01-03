using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float Smoothing;
    public Transform Player;
    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, Player.position, Smoothing);
        transform.rotation = Quaternion.Slerp(transform.rotation, Player.rotation, Smoothing);
        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
    }
}
