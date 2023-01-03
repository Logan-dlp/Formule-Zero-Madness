using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityOrbit : MonoBehaviour
{
    public float Gravity;

    public bool FixedDirection;

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.GetComponent<GravityCtrl>())
        {
            _other.GetComponent<GravityCtrl>().Gravity = this.GetComponent<GravityOrbit>();
        }
    }
}
