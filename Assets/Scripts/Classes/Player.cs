using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {

    public bool isfirstPlayer;
    public bool hasPlayedTurn;
    public bool isHumanPlayer;

    public Card currentCard;
    public List<Card> playerDeck;

	// Use this for initialization
	public Player () {
        isfirstPlayer = false;
        hasPlayedTurn = false;
        isHumanPlayer = false;

        playerDeck = new List<Card>();
        currentCard = new Card();
	}
	
}
