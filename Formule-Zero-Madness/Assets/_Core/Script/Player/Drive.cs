using UnityEngine;

public class Drive : MonoBehaviour
{
    #region Settings
    [SerializeField] float speed;
    [SerializeField] float turnSpeed;
    [SerializeField] float gravity;

    [SerializeField, Space] KeyCode accelerate = KeyCode.Z;
    [SerializeField] KeyCode brake = KeyCode.S;

    [SerializeField, Space] StartTime startTime;
    [SerializeField] RaceTime raceTime;

    Rigidbody rb;
    #endregion
    #region Meths
    void Fall()
    {
        rb.AddForce(-transform.up * gravity);
    }
    void InStartWait()
    {
        if(startTime.currentTime == 0 && raceTime.MaxTime != 0)
        {
            Move();
            Turn();
        }
    }
    void Move()
    {
        if (Input.GetKey(accelerate))
        {
            rb.AddRelativeForce(new Vector3(Vector3.forward.x, 0, Vector3.forward.z) * speed);
        }
        else if (Input.GetKey(brake))
        {
            rb.AddRelativeForce(new Vector3(Vector3.forward.x, 0, Vector3.forward.z) * -speed);
        }
        Vector3 _localVelocity = transform.InverseTransformDirection(rb.velocity);
        _localVelocity.x = 0;
        rb.velocity = transform.TransformDirection(_localVelocity);
    }
    void Turn()
    {
        float _rotation = Input.GetAxis("Horizontal") * turnSpeed;
        _rotation *= Time.deltaTime;
        transform.Rotate(0, _rotation, 0);
    }
    #endregion
    #region Meths Unity
    private void FixedUpdate()
    {
        InStartWait();
        Fall();
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    #endregion
}
