using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Collisions : MonoBehaviour
{


    public GameObject startPoint; //let us set the start point, the player, and the array of lives which are referenced later. also set up i to iterate.
    public GameObject player;
    public GameObject[] life; 
    private int i = 0;
    private game1_movement movement_script; //allows us to reference speed/acceleration from the movement script

    // Start is called before the first frame update
  
    // Update is called once per frame
    
    private void Start()
    {
        movement_script = player.GetComponent<game1_movement>();
        // on first frame, stores game1_movement script
    }


    private void OnCollisionEnter2D(Collision2D other) //when the player collides with something..
    {
        if(other.gameObject.CompareTag("Obstacle")) 
        {
            player.transform.position = startPoint.transform.position; //when player has a collision, if the other object is an obstacle, respawn them at the empty gameobject spawn point

            life[i].SetActive(false); //set the ith life indicator to be invisible, starting at i=0

            i++; //iterate i so that the next collision will turn off the 2nd life, etc

            movement_script.speed = 3; //when character respawns set their speed to the starting speed (3) and acceleration to 0
            movement_script.acceleration = 0;

            if(i > 2);
            {
                //end game
            }
           
        }
    }
}
