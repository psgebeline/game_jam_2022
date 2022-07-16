using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalTime : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI FinalTimeText; //allows scripts to be attatched to texts

    void Start()
    {
        FinalTimeText.text = "Final time: " + CountdownTimer.currentTime.ToString("0.0"); //pulls currentTime from CountdownTimer class and assigns it to be translated to text
    }
}
