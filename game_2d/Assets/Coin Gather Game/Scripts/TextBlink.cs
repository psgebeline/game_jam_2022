using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBlink : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI blinkText;

    public float BlinkFadeInTime = 0.5f;
    public float BlinkStayTime = 0.8f;
    public float BlinkFadeOutTime = 0.7f;
    private float timeChecker = 0;
    private Color color;
    //variables

    void Start()
    {
        color = blinkText.color;
    }

    void Update()
    {
        timeChecker += Time.deltaTime;
        
        if(timeChecker < BlinkFadeInTime)
        {
            blinkText.color = new Color(color.r, color.g, color.b, timeChecker / BlinkFadeInTime);
        }else if (timeChecker < BlinkFadeInTime + BlinkStayTime)
        {
            blinkText.color = new Color(color.r, color.g, color.b, 1);
        }else if(timeChecker < BlinkFadeInTime + BlinkStayTime + BlinkFadeOutTime)
        {
            blinkText.color = new Color(color.r, color.g, color.b, 1 - (timeChecker - (BlinkFadeInTime + BlinkStayTime))/BlinkFadeOutTime);
        }else
        {
            timeChecker = 0;
        }
    }
}
