using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    //create variables
    public float velocity = 10.0f;
    public Rigidbody2D rb; 
    public Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame, create movement input based on wasd/arrow input
    void Update()
    {
       movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    void FixedUpdate()
    {
        moveSprite(movement); //move the character in direction of input by calling the function below
    }

    //create a function to transform 2d position vector; normalization to account for diagonal movement?
    void moveSprite(Vector2 direction){
        rb.MovePosition((Vector2)transform.position + (direction * velocity * Time.deltaTime));
    }
}
