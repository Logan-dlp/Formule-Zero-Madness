using UnityEngine;

public class Drive : MonoBehaviour
{
    #region Settings
    [Header("Physics")]
    public float Speed;
    [SerializeField] float turnSpeed;
    [SerializeField] float gravity;
    [SerializeField] CharacterController controller;
    [SerializeField] Vector3 moveDirection = Vector3.zero;

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

    [Header("Score")]
    [SerializeField] Score score;
    [SerializeField] Tours tours;

    [Header("Sound")]
    public AudioSource BoostSound;
    [SerializeField] GameObject playerSound;

    Rigidbody rb;
    #endregion
    #region Meths
    void Fall()
    {
        // Physics.Raycast(transform.position, -transform.up, out RaycastHit _hitInfo );
        // rb.AddForce(-_hitInfo.normal * gravity);
        moveDirection.y -= gravity * Time.deltaTime;
    }
    void InStartWait()
    {
        if(startTime.currentTime == 0 && raceTime.MaxTime != 0)
        {
            Move();
            Turn();
        }else if(raceTime.MaxTime == 0)
        {
            
            if(tours.Tour >= score.score)
            {
                score.SetScore(tours.Tour);
            }
            sceneLoader.LoadScene(sceneGameOver);
        }
    }
    void Move()
    {
        if (Input.GetKey(accelerate))
        {
            // rb.AddRelativeForce(new Vector3(Vector3.forward.x, 0, Vector3.forward.z) * Speed);
            moveDirection = new Vector3(Vector3.forward.x, 0, Vector3.forward.z);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= Speed;
            playerSound.SetActive(true);
        }
        else if (Input.GetKey(brake))
        {
            // rb.AddRelativeForce(new Vector3(Vector3.forward.x, 0, Vector3.forward.z) * -Speed);
            moveDirection = new Vector3(Vector3.forward.x, 0, Vector3.forward.z);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= -Speed;
            playerSound.SetActive(true);
        }
        else
        {
            playerSound.SetActive(false);
            moveDirection = Vector3.zero;
        }
        Vector3 _localVelocity = transform.InverseTransformDirection(rb.velocity);
        _localVelocity.x = 0;
        rb.velocity = transform.TransformDirection(_localVelocity);
    }
    void Restart()
    {
        if(Input.GetKeyUp(restartButton))
        {
            sceneLoader.LoadScene(sceneToRestart);
        }
        if(Input.GetKeyUp(menuButton))
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
    private void Update()
    {
        InStartWait();
        Fall();
        Restart();
        controller.Move(moveDirection * Time.deltaTime);
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        playerSound.SetActive(false);
    }
    #endregion
}
