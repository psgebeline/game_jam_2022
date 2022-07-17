using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller; //creates a controller instance

    public float runSpeed = 40f; //default runSpeed

    public float horizontalMove = 0f; //for calc of movespeed

    bool jump = false; //status of jump

    public Animator animator; //access the animator

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;


    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed; //calcs movespeed

        if (Input.GetButtonDown("Jump")) //sets jump to true if spacebar or w is pressed
        {
            jump = true;
            animator.SetBool("isJumping", true);
        }

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove)); //sets the float variable speed in the animator to horizontal move w/ absolute value

        if(currentHealth  <= 0)
        {
            Die();
        }
    }

    void FixedUpdate()
    {
        //moves character and adjusts it to realtime resets jump
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
        animator.SetBool("isJumping", false);
    }

    void OnTriggerEnter2D(Collider2D other) //if characer collidies with the coin or enemy object it destroys it or takes damage
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }

        EnemySc e1 = other.gameObject.GetComponent<EnemySc>();

        if(e1)
        {
            Destroy(other.gameObject);
            TakeDamage(25);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    void Die()
    {
        SceneManager.LoadScene("Lose Scene");
    }   

}
