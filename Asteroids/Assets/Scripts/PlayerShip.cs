using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class PlayerShip : MonoBehaviour
{
    public bool IsShooting { get => shootInput.triggered; }

    public InputAction thrustInput;
    public InputAction turnInput;
    public InputAction shootInput;
    public Rigidbody rb;
    public Transform ShootPoint;
    public GameObject OptionsMenu;
    public GameObject Ball;
    private InputAction PlayerControls;
    public Vector3 teleport;
    public float speed;
    public float thrustSpeed;
    public float turnSpeed = 1.0f;
    public float turnDirection;
    private bool thrusting;
    private bool turning;


    private void Awake()
    {
        PlayerControls = new InputAction();
        PlayerControls.Enable();
        DontDestroyOnLoad(gameObject);
    }


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        thrustInput.Enable();
        turnInput.Enable();
        shootInput.Enable();
        shootInput.performed += ShootInput_performed;
    }
    private void Update()
    {
        KeyBinds();
    }


    // Update is called once per frame
    private void FixedUpdate()
    {
        CheckKeybins();
        CalculateBorder();
        if (thrusting)
        {
            PlayerMove();

        }
        if (turning)
        {
            Turning();
        }
        if (IsShooting)
        {
            Shoot();
        }
    }

    private void ShootInput_performed(InputAction.CallbackContext obj)
    {
        Shoot();
    }

    private void CheckKeybins()
    {
        thrusting = thrustInput.IsPressed();
        turning = turnInput.IsPressed();

    }
    private void Shoot()
    {
        Instantiate(Ball, ShootPoint.position, ShootPoint.rotation);
    }

    private void CalculateBorder()
    {
        Vector3 minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minScreenBounds.x + 1, maxScreenBounds.x - 1), Mathf.Clamp(transform.position.y, minScreenBounds.y + 1, maxScreenBounds.y - 0), transform.position.z);
    }

    private void KeyBinds()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OptionsMenu.SetActive(!OptionsMenu.activeSelf);
            Time.timeScale = (OptionsMenu.activeSelf) ? 0: 1;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("pressed");
            teleport = new Vector3(Random.RandomRange(1, 11), Random.RandomRange(1, 11), 0);
            transform.position = teleport;
        }
    }

    private void PlayerMove()
    {
        transform.position += Time.deltaTime * (transform.forward * speed); // X and Y Movement ONLY
    }
    
    private void Turning()
    {
        transform.Rotate(new Vector3(0, Input.GetAxisRaw("Horizontal") * turnSpeed, 0));
    }
}
