using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 12f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * _speed * Time.deltaTime);

        if (transform.position.z <= -8f)
        {
            float randomX = Random.Range(-9f,9f);
            transform.position = new Vector3(randomX,0,7);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
     if(other.tag == "Player")
     {
        Destroy(this.gameObject);
     }

    if (other.tag == "Lazer")
    {
        Destroy(other.gameObject);
        Destroy(this.gameObject);
    }
    if (other.tag == "Cannon")
    {
        Destroy(this.gameObject);
    }    
    
    }


}
