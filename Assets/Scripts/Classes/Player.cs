using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {

    public bool isfirstPlayer;
    public bool hasPlayedTurn;
    public bool isHumanPlayer;

    public List<Card> playerDeck;
    private Card my_currentCard;

    public delegate void OnValueChangeDelegate();
    public event OnValueChangeDelegate OnValueChange;

    public Card currentCard 
    {
        get { return my_currentCard; }
        set {
            if (my_currentCard == value) return;
            my_currentCard = value;
            if(OnValueChange != null) {
                OnValueChange();
            }
        }
    }


	// Use this for initialization
	public Player () {
        isfirstPlayer = false;
        hasPlayedTurn = false;
        isHumanPlayer = false;

        playerDeck = new List<Card>();
        currentCard = new Card();
	}
	
}
