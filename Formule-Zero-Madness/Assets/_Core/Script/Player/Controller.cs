using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Controller : MonoBehaviour
{
    #region Settings
    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] Transform playerOrientation;

    Rigidbody rb;
    Vector3 moveDirection;

    float horizontalInput;
    float verticalInput;

    float rotationY;
    #endregion
    #region Meths
    void SetRigidbody()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    void ControllerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        // peut être à modifier !! ^
        verticalInput = Input.GetAxisRaw("Vertical");
    }
    void MovePlayer()
    {
        moveDirection = playerOrientation.forward * verticalInput;
        rb.AddForce(moveDirection.normalized * moveSpeed, ForceMode.Force);

        rotationY += horizontalInput;
        transform.rotation = Quaternion.Euler(0, rotationY, - horizontalInput * 10 * Time.deltaTime);
    }
    void LimitVelocity()
    {
        Vector3 _vel = new Vector3(rb.velocity.x,  0,rb.velocity.y);
        if(_vel.magnitude > moveSpeed)
        {
            Vector3 _limitVel = _vel.normalized * moveSpeed;
            rb.velocity = new Vector3(_limitVel.x, rb.velocity.y, _limitVel.z);
        }
    }
    #endregion
    #region Meths Unity
    private void Start()
    {
        SetRigidbody();
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void Update()
    {
        ControllerInput();
        LimitVelocity();
    }
    #endregion
}
