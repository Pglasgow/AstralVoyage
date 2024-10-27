using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player : MonoBehaviour
{
    private float _speed = 12f;
    [SerializeField]
    private GameObject _lazerPrefab;
    [SerializeField]
    private GameObject _cannonPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        //Player Start Position
        transform.position = new Vector3(0,0,0);

    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

        //Spawns lazer Prefab
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(_lazerPrefab, transform.position + new Vector3(0,0,1.5f),Quaternion.Euler(90,0,0));
        }
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            Instantiate(_cannonPrefab, transform.position + new Vector3(0, 0, 1.5f), Quaternion.identity);
        }
        
            
        


    }


    void CalculateMovement()
    {
        float horizonalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        //Player Movement
        transform.Translate(Vector3.right *horizonalInput* _speed * Time.deltaTime);
        transform.Translate(Vector3.up *verticalInput* _speed * Time.deltaTime);
        if (verticalInput > 0)
        {
            _speed = 12;
        }
        else if (verticalInput <0 )
        {
            _speed = 5;
        }
        
        
        // Player boundries
        if(transform.position.x >= 10)
        {
            transform.position = new Vector3(10,0,transform.position.z);
        }
        else if(transform.position.x <= -10)
        {
           transform.position = new Vector3(-10,0,transform.position.z); 
        }
        if (transform.position.z >=4.5f)
        {
            transform.position = new Vector3(transform.position.x,0,4.5f);
        }
        else if(transform.position.z <= -4)
        {
           transform.position = new Vector3(transform.position.x,0,-4);
        }
    }

    
}
