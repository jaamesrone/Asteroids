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
    public Transform playerSpawnPoint;
    public GameObject Player;
    public Transform ShootPoint;
    public GameObject Ball;
    Vector2 Fire;
    

    // Start is called before the first frame update

    // Start is called before the first frame update
    private void Awake()
    {
        PlayerControls = new InputAction();
        PlayerControls.Enable();
        rb = GetComponent<Rigidbody>();
    }


    void Start()
    {
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += Time.deltaTime * (new Vector3(moveVal.x, moveVal.y, 0) * speed);
        this.transform.Rotate(new Vector3(0.0f, DeltaPointer.x, 0f) * lookSpeed, Space.World);
        this.transform.Rotate(new Vector3(-DeltaPointer.y, 0.0f, 0f) * lookSpeed, Space.Self);
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

    }

    public void Shoot()
    {
        Instantiate(Ball, ShootPoint.position, ShootPoint.rotation);
        
        
    }


    public void OnLook(InputValue Value)
    {
        //Delta reads the difference between positions of the mouse, in other words how much it moved.
        DeltaPointer = Value.Get<Vector2>();
    }


    public void OnMove(InputValue Value)//new movement input
    {
        moveVal = Value.Get<Vector2>();
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Player.transform.position = playerSpawnPoint.position;
        }
    }

}
