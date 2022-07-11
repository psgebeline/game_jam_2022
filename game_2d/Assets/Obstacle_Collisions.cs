using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Collisions : MonoBehaviour
{


    public GameObject startPoint;
    public GameObject player;
    public GameObject[] life; 
    private int i = 0;


    // Start is called before the first frame update
  
    // Update is called once per frame
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Obstacle")) 
        {
            player.transform.position = startPoint.transform.position; //when this object has a collision, if the other object is the player, respawn them at the empty gameobject spawn point
            life[i].SetActive(false); //set the ith life indicator to be invisible and then iterate i
            i++;
            if(i > 2);
            {
                //end game
            }
           
        }
    }
}
