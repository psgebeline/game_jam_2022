using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    float currentTime = 0;
    float startingTime = 10f;

    [SerializeField] public TextMeshProUGUI countdownText;

    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("00");

        if(currentTime <= 0)
        {
            currentTime = 0;
            SceneManager.LoadScene("Lose Screen");
        } 
    }
}
