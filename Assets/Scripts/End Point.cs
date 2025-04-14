using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(Delivery.numberOfCustomers == 2)
        {
            Debug.Log("End Game");
            Destroy(gameObject, 0.5f);
        }
        
    }
}
