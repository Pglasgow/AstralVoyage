using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class lazer : MonoBehaviour
{
    [SerializeField]
    private float speed = 10.5f; //Lazer speed

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Lazer moves in forward direction
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        //Lazer destoyed
        if(transform.position.z >= 6.5)
        {
            Destroy(gameObject);
        }
    }

}
