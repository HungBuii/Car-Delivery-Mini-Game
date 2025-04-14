using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] public bool delivered;
    [SerializeField] private float steerSpeed = 60f;
    [SerializeField] private float moveSpeed = 10f;

    Delivery delivery;

     void Start() 
    {
        delivery = GetComponent<Delivery>();
    }

    void Update()
    {
        // Steer the car based on player input
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);

        // Move the car forward, backward
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(0, moveAmount, 0);

        delivered = delivery.delivered;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        moveSpeed -= 2f;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Boost Speed")
        {
            moveSpeed += 20f;
            Destroy(collision.gameObject, 0.5f);
        }
        if (collision.tag == "Slow Speed")
        {
            moveSpeed -= 5f;
            Destroy(collision.gameObject, 0.5f);
        }
        if (collision.tag == "Customer" && delivered == true)
        {
            moveSpeed += 10f;
        }
    }
}
