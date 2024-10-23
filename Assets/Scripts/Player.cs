using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    
    public int coins = 0;

    public void AddCoin()
    {
        coins += 1;
        Debug.Log("Coins: " + coins);
    }
}