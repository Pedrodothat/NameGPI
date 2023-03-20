using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    playermanager playerManager;
    // Start is called before the first frame update
    void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<playermanager>();
    }

    // Update is called once per frame
   private void OnTriggerEnter2d(Collider2D collision)
    {
        {
            if (collision.gameObject.tag == "Player")
            {
                playerManager.TakeDamage();
            }
        }
    }
}
