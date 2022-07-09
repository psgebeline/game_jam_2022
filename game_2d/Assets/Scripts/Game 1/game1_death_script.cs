using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game1_death_script : MonoBehaviour
{

    public GameObject startPoint;
    public GameObject Player; //storing game objects


   
   
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Player.transform.position = startPoint.transform.position; //when this object has a collision, if the other object is the player, respawn them at the empty gameobject spawn point
        }
    }
}
