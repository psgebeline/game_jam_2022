using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;
    float diagonalSpeed = 0.8f;

    public float runSpeed = 20.0f;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); //-1 is left
        vertical = Input.GetAxisRaw("Vertical"); //-1 is down
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical !=0) //diagonal movement 
        {
            horizontal *= diagonalSpeed;
            vertical *= diagonalSpeed;
        }
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
}
