using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;



public class Player : MonoBehaviour
{
    private float _speed = 12f;
    [SerializeField]
    private GameObject _lazerPrefab;
    [SerializeField]
    private GameObject _cannonPrefab;
    [SerializeField]
    private float _fireRateLazer = 0.3f;
    [SerializeField]
    private float _canFireLazer = -0.3f;
    [SerializeField]
    private float _fireRateCannon = 5;
    [SerializeField]
    private float _canFireCannon = -5f;
    [SerializeField]
    private int _health = 100;

    
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

        Shooting();

        
            
        


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
        if (horizonalInput > 0)
        {
            _speed = 12;
        }
        else if (horizonalInput <0)
        {
            _speed =12;
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
    void Shooting()
    {
      
        //Spawns lazer / Cannon Prefab
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > _canFireLazer)
        {
            _canFireLazer = Time.time + _fireRateLazer;
            Instantiate(_lazerPrefab, transform.position + new Vector3(0,0,1.5f),Quaternion.Euler(90,0,0));
        }
        if(Input.GetKeyDown(KeyCode.Mouse1) && Time.time > _canFireCannon)
        {

            _canFireCannon = Time.time + _fireRateCannon;
            Instantiate(_cannonPrefab, transform.position + new Vector3(0, 0, 1.5f), Quaternion.identity);
        }  
    }
    public void Damage()
    {
        _health -= 5 ;

        if(_health < 1)
        {
            Destroy(this.gameObject);
        }
    }

}
