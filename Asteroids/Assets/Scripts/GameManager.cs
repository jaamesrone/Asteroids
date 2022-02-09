using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerShip player;
    private static GameManager _instance;
    public static SomeClass Instance { get { return _instance; } }

    // Start is called before the first frame update
    void Start()
    {
        
    }

   
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Player.transform.position = playerSpawnPoint.position;
        }
    }
}
