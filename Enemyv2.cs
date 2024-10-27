using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 12f;
    private Vector3 _directionToPlayer; // Fixed direction towards player's initial position

    void Start()
    {
        // Find the player by tag and calculate direction to the initial player position
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            // Calculate the initial direction to the player's position
            _directionToPlayer = (player.transform.position - transform.position).normalized;
        }
        else
        {
            // Default direction in case player is not found
            _directionToPlayer = Vector3.back;
        }
    }

    void Update()
    {
        // Move in the fixed direction calculated in Start()
        transform.Translate(_directionToPlayer * _speed * Time.deltaTime, Space.World);

        // If enemy goes out of bounds, reset its position
        if (transform.position.z <= -8f)
        {
            float randomX = Random.Range(-9f, 9f);
            transform.position = new Vector3(randomX, 0, 7);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.Damage();
            }
            Destroy(this.gameObject);
        }

        if (other.CompareTag("Lazer"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }

        if (other.CompareTag("Cannon"))
        {
            Destroy(this.gameObject);
        }
    }
}
