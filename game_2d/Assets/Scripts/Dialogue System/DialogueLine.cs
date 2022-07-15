using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem
{
    public class DialogueLine : DialogueBaseClass //inherit functions from the other script
    {
        private Text textHolder;
        [SerializeField] private string input; //storing variables from 1st script

        private void Awake()
        {
            textHolder = GetComponent<Text>();

            StartCoroutine(WriteText(input, textHolder));

        }

        
    }
}

