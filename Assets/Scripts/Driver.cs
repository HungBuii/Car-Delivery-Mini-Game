using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] private float steerSpeed = 60f;
    [SerializeField] private float moveSpeed = 10f;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Steer the car based on player input
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);

        // Move the car forward, backward
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(0, moveAmount, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ouch!");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Package")
        {
            spriteRenderer.color = collision.GetComponent<SpriteRenderer>().color;
            Debug.Log("Package " + spriteRenderer.color.ToString() + " collected!");
            Destroy(collision.gameObject, 0.5f);
        }
    }
}
