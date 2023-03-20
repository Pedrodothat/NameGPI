using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playermanager manager = collision.GetComponent<playermanager>();

           if (manager)
            {
               bool pickup = manager.PickupItem(gameObject);

               if (pickup)
                {
                    Destroy(gameObject);
                }
            }
       
               
        }
    }
}
