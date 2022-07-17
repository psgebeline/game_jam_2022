using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public static float currentTime = 0;
    float startingTime = 6.5f;

    //allows for a text to be set with the script
    [SerializeField] public TextMeshProUGUI countdownText;

    void Start()
    {
        //sets currentTime to startingTime
        currentTime = startingTime;
    }

    void Update() 
    {
        //substracts time from current time to countdown
        currentTime -= 1 * Time.deltaTime;
        //translates float to text using ToString
        countdownText.text = currentTime.ToString("0.0");

        if(currentTime <= 0) //if the timer hits 0, the screen loads to the Lose Screen scene and resets the time.
        {
            currentTime = 0;
            SceneManager.LoadScene("Lose Screen");
        } 
    }
}
