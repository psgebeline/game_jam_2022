using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem
{
    public class DialogueBaseClass : MonoBehaviour
    {
        //this coroutine is responsible for showing letters one by one. essentially
        //it loops over every letter, putting the letter into the textholder and waiting
        //0.1 seconds before displaying the next letter. "protected" lets it be called in 
        //the child class (dialogue line script)
        
        protected IEnumerator WriteText(string input, Text textHolder, Color textColor, Font textFont) 
        {
            textHolder.color = textColor;
            textHolder.font = textFont;
            for(int i = 0; i < input.Length; i++)
            {
                textHolder.text += input[i];
                yield return new WaitForSeconds(0.1f);
            }

        }
    }


}


