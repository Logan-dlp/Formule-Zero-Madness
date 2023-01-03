using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityCtrl : MonoBehaviour
{
    public GravityOrbit Gravity;
    Rigidbody rb;

    public float RotationSpeed = 20;

    void Gravit()
    {
        if (Gravity)
        {
            Vector3 _gravityUp = Vector3.zero;
            if (Gravity.FixedDirection)
            {
                _gravityUp = Gravity.transform.up;
            }
            else
            {
                _gravityUp = (transform.position - Gravity.transform.position).normalized;
            }

            Vector3 _localUp = transform.up;

            Quaternion _targetRotation = Quaternion.FromToRotation(_localUp, _gravityUp) * transform.rotation;

            transform.up = Vector3.Lerp(transform.up, _gravityUp, RotationSpeed * Time.deltaTime);

            rb.AddForce((-_gravityUp * Gravity.Gravity) * rb.mass);
        }
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Gravit();
    }
}
