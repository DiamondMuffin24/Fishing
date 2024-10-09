using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("Object entered SellArea: " + other.name);

        // Check if the object entering is a coin
        if (other.CompareTag("Pickup")) // Make sure your coin object has the tag "Coin"
        {
            // Get the Player component (make sure the player has the script attached)
            Player player = FindObjectOfType<Player>();
            if (player != null)
            {
                player.AddCoin();
            }

            // Optionally, destroy the coin after it is collected
            Destroy(other.gameObject);
        }
        else
        {
            Debug.Log("Object is not a coin: " + other.name);
        }
    }
}