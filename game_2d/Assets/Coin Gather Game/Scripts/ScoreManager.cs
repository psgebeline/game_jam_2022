using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance; 
    public TextMeshProUGUI text;
    int score; //variables / calls

    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }

        //resets
    }

    public void ChangeScore(int coinValue) //+1 to score when ChangeScore is called in "Coin" and ToString
    {
        score += coinValue;
        text.text = "" + score.ToString();
    }

    void Update()
    {
        if(score == 5) //sets win condition, ends scene and transitions to new one
        {
            SceneManager.LoadScene("Win Screen");
        }
    }
}