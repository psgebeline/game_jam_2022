using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller; //creates a controller instance

    public float runSpeed = 40f; //default runSpeed

    public float horizontalMove = 0f; //for calc of movespeed

    bool jump = false; //status of jump

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed; //calcs movespeed

        if (Input.GetButtonDown("Jump")) //sets jump to true if spacebar or w is pressed
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        //moves character and adjusts it to realtime resets jump
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;

    }

    void OnTriggerEnter2D(Collider2D other) //if characer collidies with the coin object it destroys it
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }
    }
}
