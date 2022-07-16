using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class game_manager : MonoBehaviour
{
    public Sprite[] cardFace;
    public Sprite cardBack;
    public GameObject[] cards;
    public Text matchText; //storing variables

    private bool _init = false; 
    private int _matches = 6;

    
    
    
    
    
    
    void Update()
    {
        if(!_init) //if the card is not initialized, initialize it.
        {
            initializeCards();
        }
        if(Input.GetMouseButtonUp(0)) //if a card is clicked, check what card it is
        {
            checkCards();
        }
    }

    void initializeCards() //nested for loop, first for matches, second for all card types
    {
        
        for(int i = 0; i < cards.Length; i++)
        {
            cards[i].GetComponent<Card>().initialized = false;
        }
        
        for(int id = 0; id < 2; id++)
        {
            for(int i = 1; i < 7; i++)
            {
                bool test = false;
                int choice = 0;
                while(!test)
                {
                    choice = Random.Range(0, cards.Length);
                    test = !(cards[choice].GetComponent<Card>().initialized); //set test to the 
                    //opposite of if the card is initialized -- if it is initialized, make test
                    //false, and vice versa
                }
                cards[choice].GetComponent<Card>().cardValue = i;
                cards[choice].GetComponent<Card>().initialized = true; 

            }

            foreach(GameObject c in cards)
            {
                c.GetComponent<Card>().setupGraphics();
            }
            if(!_init)
            {
                _init = true;
            }


        }
    }

    public Sprite getCardBack()
    {
        return cardBack;
    }

    public Sprite getCardFace(int i)
    {
        return cardFace[i - 1];
    }

    void checkCards()
    {
        List<int> c = new List<int>();

        for(int i = 0; i < cards.Length; i++)
        {
            if(cards[i].GetComponent<Card>().state == 1)
            {
                c.Add(i);
            }
        }
        if(c.Count ==2)
        {
            cardComparison(c);
        }
    }

    void cardComparison(List<int> c)
    {
        Card.DO_NOT = true;

        int x = 0;

        if(cards[c[0]].GetComponent<Card>().cardValue == cards[c[1]].GetComponent<Card>().cardValue)
        {
            x = 2;
            _matches--;
            matchText.text = "Matches Remaining: " + _matches;
            if(_matches == 0)
            {
                //end game
            }
            
        }

        for(int i = 0; i < c.Count; i++)
        {
            cards[c[i]].GetComponent<Card>().state = x;
            cards[c[i]].GetComponent<Card>().falseCheck();
        }

    }
    
}