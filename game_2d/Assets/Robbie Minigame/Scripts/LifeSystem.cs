using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LifeSystem : MonoBehaviour
{
  public GameObject[] lives; //array of lives
  public int life; //variable to keep up with lives
  CountdownTimer timer; //makes timer
  private bool dead;
  
  void Start()
  {
    life = lives.Length;
  }

  void Update()
  {
    if(dead == true)
    {
        SceneManager.LoadScene("Lose Screen"); //if dead is true it loads the lose screen
    }
  }
//on frame updates the life counter
  public void TakeDamage()
  {
    if(timer.currentTime >= 0)
    {
        if(timer.currentTime <= 0) //function subtracts -1 from the life variable (equal to length of array) then subtracts that gameobj associated with it, if life < 1 bool dead changed to true triggers if dead in update
        {
            life -= 1;
            Destroy(lives[life].gameObject);

            if(life < 1)
            {
            dead = true;
            }
    }
    }
  }
}
