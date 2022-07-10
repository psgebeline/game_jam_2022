using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game1_death_script : MonoBehaviour
{

    public GameObject startPoint;
    public GameObject Player; //storing game objects
    public GameObject[] life; 
    private int i = 0;


   
   
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player")) 
        {
            Player.transform.position = startPoint.transform.position;
            //Debug.Log(life[i]);
            //if(i <=2)
            {
                //Player.transform.position = startPoint.transform.position; //when this object has a collision, if the other object is the player, respawn them at the empty gameobject spawn point
                //Destroy(life[i]);
                //i++;
                
            }
            //else
            {
                //end game
            }
            
            
        }
    }   
}
