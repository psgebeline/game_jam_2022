using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueHolder : MonoBehaviour
    {

        private void Awake()
        {
            StartCoroutine(dialogueSequence()); //initializes dialogue sequence
        }
        
        
        private IEnumerator dialogueSequence()
        {
            for(int i = 0; i < transform.childCount; i++) //loops through all child objects and activates them accordingly
            {
                Deactivate(); //call the below function before activating new dialogue, to deactivate the other lines
                transform.GetChild(i).gameObject.SetActive(true);
                yield return new WaitUntil(() => transform.GetChild(i).GetComponent<DialogueLine>().finished); //tells script when the previous dialogue is done and it can present the next one

            }

        }

        private void Deactivate()
        {
            for(int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }

        }
   
    }
}
