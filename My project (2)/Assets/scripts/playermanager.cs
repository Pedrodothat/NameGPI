using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermanager : MonoBehaviour
{
    move playerMovement;
    public int coinCount;
    public int maxHealth;
    public int CurrentHealth;

    void Start()
    {
        playerMovement = GetComponent<move>();
    }
     
    private void update()
    {
        if(CurrentHealth <- 0)
        {
            PauseGame();
        }
    }


    public bool PickupItem(GameObject obj)
    {
        switch (obj.tag)
        {
            case "Currency":
            coinCount++;
                return true;
            case "speed+":
                playerMovement.SpeedPowerUp();
                return true;
            default:
                Debug.Log("item tag or refrence not set.");
                return false;
        }
       
    }
    public void TakeDamage()
    {
        CurrentHealth -= 1;
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame ()
    {
        Time.timeScale = 1;
    }
}
