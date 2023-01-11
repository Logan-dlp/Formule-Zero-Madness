using UnityEngine;

public class Drive : MonoBehaviour
{
    #region Settings
    [Header("Physics")]
    public float Speed;
    [SerializeField] float turnSpeed;
    [SerializeField] float gravity;

    [Header("Move")]
    [SerializeField] KeyCode accelerate = KeyCode.Z;
    [SerializeField] KeyCode brake = KeyCode.S;

    [Header("Timer")]
    [SerializeField] StartTime startTime;
    [SerializeField] RaceTime raceTime;

    [Header("Restart")]
    [SerializeField] KeyCode restartButton = KeyCode.A;
    [SerializeField] string sceneToRestart;
    [SerializeField] KeyCode menuButton = KeyCode.E;
    [SerializeField] string sceneToMenu;
    [SerializeField] string sceneGameOver;
    [SerializeField] SceneLoader sceneLoader;

    [Header("Player Detection")]
    public float LayerPlayer = 3;

    Rigidbody rb;
    #endregion
    #region Meths
    void Fall()
    {
        Physics.Raycast(transform.position, -transform.up, out RaycastHit _hitInfo );
        rb.AddForce(-_hitInfo.normal * gravity);
    }
    void InStartWait()
    {
        if(startTime.currentTime == 0 && raceTime.MaxTime != 0)
        {
            Move();
            Turn();
        }else if(raceTime.MaxTime == 0)
        {
            sceneLoader.LoadScene(sceneGameOver);
        }
    }
    void Move()
    {
        if (Input.GetKey(accelerate))
        {
            rb.AddRelativeForce(new Vector3(Vector3.forward.x, 0, Vector3.forward.z) * Speed);
        }
        else if (Input.GetKey(brake))
        {
            rb.AddRelativeForce(new Vector3(Vector3.forward.x, 0, Vector3.forward.z) * -Speed);
        }
        Vector3 _localVelocity = transform.InverseTransformDirection(rb.velocity);
        _localVelocity.x = 0;
        rb.velocity = transform.TransformDirection(_localVelocity);
    }
    void Restart()
    {
        if(Input.GetKeyDown(restartButton))
        {
            sceneLoader.LoadScene(sceneToRestart);
        }
        if(Input.GetKeyDown(menuButton))
        {
            sceneLoader.LoadScene(sceneToMenu);
        }
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
        Restart();
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    #endregion
}
