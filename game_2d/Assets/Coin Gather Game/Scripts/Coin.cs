using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1; //assigns the value of score of the coin to 1

    public void OnTriggerEnter2D(Collider2D other) //if the player collidies with the coin it adds a score to the player's score using the scoremanager class
    {
        if(other.gameObject.CompareTag("Player"))
        {
            ScoreManager.instance.ChangeScore(coinValue);
        }
    }
}
