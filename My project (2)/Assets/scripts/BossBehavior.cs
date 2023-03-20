using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    Transform player;
    public bool isFlipped = false;
    public int bossHealth = 10;
    public float attackRange;
    public bool phase2 = false;
    public bool phase3 = false;
    public bool isDead = false;
    playermanager PlayerManager;
    public float speed = 5f;
    public float timer;
    public float coolDown;
    public GameObject projectile;
    public Transform shotLocation;
    public GameObject projectile2;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        PlayerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<playermanager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(bossHealth <7 && bossHealth > 3)
        {
            phase2 = true;
            Debug.Log("Phase 2");
        }
        else if (bossHealth <3 && bossHealth > 1)
        {
            phase2 = false;
            phase3 = true;
            Debug.Log("Phase 2");
        }
        else if (bossHealth <= 0)
        {
            phase3 = false;
            isDead = true;
            Debug.Log("isDead");
        }
        timer = Time.deltaTime;
    }
    public void ProjectileShoot()
    {
        if (timer > coolDown)
        {
            if (phase2)
            {
                GameObject clone = Instantiate(projectile, shotLocation.position, Quaternion.identity);
                timer = 0;
            }
            else if (phase3)
            {
                GameObject clone = Instantiate(projectile2, shotLocation.position, Quaternion.identity);
                timer = 0;
            }
        }
    }
    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;
        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0, 180, 0);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0, 180, 0);
            isFlipped = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        {
            PlayerManager.TakeDamage();
        }
    }

}
