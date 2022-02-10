using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShip : MonoBehaviour
{
    Vector2 DeltaPointer;
    public float lookSpeed;
    public Vector2 moveVal;
    public float speed;
    public Rigidbody rb;
    private InputAction PlayerControls;
    public int lives;
    
    
    public Transform ShootPoint;
    public GameObject Ball;
    Vector2 Fire;
    private bool thrusting;
    private bool turning;
    public float thrustSpeed;




    public InputAction thrustInput;
    public InputAction turnInput;
    public InputAction shootInput;
    private float turnDirection = 5.0f;
    public float turnSpeed = 1.0f;
    // Start is called before the first frame update

    // Start is called before the first frame update
    private void Awake()
    {
        PlayerControls = new InputAction();
        PlayerControls.Enable();
    }


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        thrustInput.Enable();
        turnInput.Enable();
        shootInput.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        thrusting = thrustInput.IsPressed();
        turning = turnInput.IsPressed();
        turnDirection = turnInput.ReadValue<float>();

        if (shootInput.triggered)
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        
        if (thrusting)
        {
            Debug.Log("Im i being pressed");
            transform.position += Time.deltaTime * (transform.forward * speed); // X and Y Movement ONLY
            //rb.AddForce(transform.forward * thrustSpeed * Time.deltaTime, ForceMode.Force);
        }

        if (turning)
        {

            Debug.Log("im i being pressed");
            transform.Rotate(new Vector3(0, Input.GetAxisRaw("Horizontal") * turnSpeed, 0));
        }

    }

    public void Shoot()
    {
        Instantiate(Ball, ShootPoint.position, ShootPoint.rotation);
    }

    public void OnMove(InputValue Value)//new movement input
    {
        moveVal = Value.Get<Vector2>();
    }
    




}
