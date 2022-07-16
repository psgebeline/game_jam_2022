using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game1_movement : MonoBehaviour
{
    public float speed; //control move speed
    private float Move; //holds horizontal direction input
    public float jump; //control jump speed
    private Rigidbody2D rb; //assigns 2D RB
    public float acceleration; //creates acceleration parameter
    public float maxSpeed; //acceleration cap
    
    public bool airborne; //used to prevent jumping while in midair


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //self-explanatory, game needs to know what "rb" is as soon as the game starts
    }

    // Update is called once per frame
    void Update()
    {
        if(acceleration < maxSpeed);
        {

            acceleration += 1;
            rb.velocity = new Vector2(speed + 0.75f*acceleration*Time.deltaTime, rb.velocity.y); //makes the player move at speed plus acceleration which incrementally increases, y velocity remains unchanged bc horizontal input has no affect on vertical speed.
        }


        if(Input.GetButtonDown("Jump") && airborne == false) //this statement will not execute when the player is in the air
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump)); //makes the player jump when spacebar is pressed by adding a vertical force to it which depends on jump speed
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground")) //the ground has tag "Ground", so when our player's collider hits the ground's collider, this if statement will execute
        {
            airborne = false; //AKA if the player is on the ground then they are not airborne. revolutionary, i know.
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            airborne = true; //same as above, if player exits collision with the ground, then they are airborne
        }
    }

}
