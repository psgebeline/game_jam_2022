using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem
{
    public class DialogueLine : DialogueBaseClass //inherit functions from the other script
    {
        private Text textHolder;
        
        [Header ("Text Options")]
        [SerializeField] private string input; //storing variables from 1st script
        [SerializeField] private Color textColor;
        [SerializeField] private Font textFont;

        private void Awake()
        {
            textHolder = GetComponent<Text>();

            StartCoroutine(WriteText(input, textHolder, textColor, textFont));

        }

        
    }
}

