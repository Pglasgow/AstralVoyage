using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f; //Lazer speed
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Cannon moves in forward direction
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        //Cannon destoyed
        if(transform.position.z >= 6.5)
        {
            Destroy(gameObject);
        }
    }
}
