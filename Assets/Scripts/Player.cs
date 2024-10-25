using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int coins = 0;
    public GameObject objectToDisable; // Reference to the object to disable

    public void AddCoin()
    {
        coins += 1;
        Debug.Log("Coins: " + coins);

        // Check if the player has 5 coins
        if (coins >= 5)
        {
            DisableObject();
        }
    }

    private void DisableObject()
    {
        if (objectToDisable != null)
        {
            objectToDisable.SetActive(false);
            Debug.Log("Object disabled after collecting 5 coins.");
        }
    }
}