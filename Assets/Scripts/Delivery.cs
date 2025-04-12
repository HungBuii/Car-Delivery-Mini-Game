using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    // bool delivered = false;
    bool hasPackage = false;
    string packageColor;
    SpriteRenderer spriteRenderer;
    Driver driver;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        driver = GetComponentInChildren<Driver>();
    }

    // void Update() 
    // {
    //     driver.delivered = delivered;
    // }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Package" && !hasPackage)
        {
            spriteRenderer.color = collision.GetComponent<SpriteRenderer>().color;
            packageColor = collision.GetComponent<Package>().packageColor;
            Debug.Log("Package " + packageColor + " collected!");
            hasPackage = true;
            // delivered = false;
            Destroy(collision.gameObject, 0.5f);
        }
        if (collision.tag == "Customer" && hasPackage && packageColor == collision.GetComponent<Package>().packageColor)
        {
            Debug.Log("Package delivered to " + packageColor + " customer sucessfull!");
            hasPackage = false;
            // delivered = true;
            spriteRenderer.color = Color.white;
            Destroy(collision.gameObject, 0.5f);
        }
    }
}
