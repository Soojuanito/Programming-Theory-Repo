using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    private float speed = 20.0f;
    private Rigidbody PlayerRb;
    private float zBound = 8;

    // Start is called before the first frame update
    void Start()
    // ENCAPSULATION
    {
        PlayerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        PlayerRb.AddForce(Vector3.forward * speed * verticalInput);
        PlayerRb.AddForce(Vector3.right * speed * horizontalInput);

        if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }
        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }

    }

    private void OnCollisionEnter(Collision collision)
    // ABSTRACTION
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
        }
    }
}
