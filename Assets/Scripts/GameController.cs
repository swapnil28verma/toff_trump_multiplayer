using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

public class GameController : MonoBehaviour
{

    string pathToJson;
    string jsonString;

    //The gameController instance. We will use this to access variables/functions of the GameController class.
    public static GameController gameControllerInstance;

    public List<GameObject> playerList;

    List<Card> playerActiveCards;
    CardDeck activeDeck;

    int winnerIndex = 0;

    //Initialise the singleton gameControllerInstance.
    private void Awake()
    {
        if(gameControllerInstance == null) {
            gameControllerInstance = this;
        } else if (gameControllerInstance != this) {
            Destroy(gameObject);
        }
    }
    // Use this for initialization of other variables
    void Start()
    {
        Debug.Log("Start for Gamecontroller called");

        playerActiveCards = new List<Card>();

        //Get the JSON data from the json file
        getJsonData();

        //Shuffle the card deck
        ShuffleDeck();

        //Distribute cards from deck
        distributeCards();

    }

    private void ShuffleDeck()
    {
        for (int i = 0; i < activeDeck.deck.Length; i++)
        {
            Card temp = activeDeck.deck[i];
            int randomIndex = UnityEngine.Random.Range(i, activeDeck.deck.Length);
            activeDeck.deck[i] = activeDeck.deck[randomIndex];
            activeDeck.deck[randomIndex] = temp;
        }
    }

    public void getJsonData() {

        pathToJson = Application.streamingAssetsPath + "/sample.json";
        jsonString = File.ReadAllText(pathToJson);
        jsonString = jsonString.Replace("\n", "");
        jsonString = jsonString.Replace("\t", "");
        jsonString = jsonString.Replace(" ", "");
        activeDeck = JsonUtility.FromJson<CardDeck>(jsonString);
    }

    public void distributeCards() {
        int playerIndex = 0;
        PlayerController player;

        foreach (Card card in activeDeck.deck) {
            player = playerList[playerIndex].GetComponent<PlayerController>();
            player.GetPlayer().playerDeck.Add(card);
            playerIndex++;
            if(playerIndex>3) {
                playerIndex = 0;
            }
        }

        playerActiveCards.RemoveRange(0, playerActiveCards.Count);
        //Set the active cards for all players
        for (playerIndex = 0; playerIndex < 4; playerIndex++)
        {
            player = playerList[playerIndex].GetComponent<PlayerController>();
            player.GetPlayer().currentCard = player.GetPlayer().playerDeck[0];
        }

    }

    /* 
     * Function defining the basic logic of one round
     * 
     * cardItemIndex => Index of the field that was played
     */
    public void gameRound(int cardItemIndex)
    {
        //Fetch the played values from other players.
        getPlayedValues();
        
        //Calculate the Winner of this round
        calculateWinner(cardItemIndex);

        //Pass all the played cards to the round winners deck
        refreshDecksAfterRound();

        //Check if the game has finished or not
        if (!hasGameEnded())
        {
            //Set isFirstPlayerTimer=true for round winner
            //Reset timer
            //Change Active cards
            prepNextMove();
        }

    }

    /*
     * Get the played values from all the players in the game.
     */
    private void getPlayedValues()
    {
        foreach (GameObject player in playerList) {
            Player playerComponent = player.GetComponent<PlayerController>().GetPlayer();
            Card card = playerComponent.currentCard as Card;
            playerActiveCards.Add(card);
        }
    }

    /*
     * Determine the winner of the round
     * 
     *  cardItemIndex => Index of the field that was played
     */
    private void calculateWinner(int cardItemIndex)
    {
        int playedValue;
        int index = 0;
        int highestValue = 0;

        switch (cardItemIndex)
        {
            case 0:
                {
                    foreach (Card card in playerActiveCards)
                    {
                        playedValue = int.Parse(card.money);
                        if (playedValue > highestValue)
                        {
                            highestValue = playedValue;
                            winnerIndex = index;
                        }
                        index++;
                    }
                    break;
                }
            case 1:
                {
                    foreach (Card card in playerActiveCards)
                    {
                        playedValue = int.Parse(card.properties);
                        if (playedValue > highestValue)
                        {
                            highestValue = playedValue;
                            winnerIndex = index;
                        }
                        index++;
                    }
                    break;
                }
            case 2:
                {
                    foreach (Card card in playerActiveCards)
                    {
                        playedValue = int.Parse(card.marriages);
                        if (playedValue > highestValue)
                        {
                            highestValue = playedValue;
                            winnerIndex = index;
                        }
                        index++;
                    }
                    break;
                }
            case 3:
                {
                    foreach (Card card in playerActiveCards)
                    {
                        playedValue = int.Parse(card.personalstaf);
                        if (playedValue > highestValue)
                        {
                            highestValue = playedValue;
                            winnerIndex = index;
                        }
                        index++;
                    }
                    break;
                }
            case 4:
                {
                    foreach (Card card in playerActiveCards)
                    {
                        playedValue = int.Parse(card.lackofsense);
                        if (playedValue < highestValue)
                        {
                            highestValue = playedValue;
                            winnerIndex = index;
                        }
                        index++;
                    }
                    break;
                }

        }
    }

    private void refreshDecksAfterRound()
    {

        int playerIndex = 0;
        Player player;

        //Remove the currently active card from the decks of all players.
        for (playerIndex = 0; playerIndex < 4; playerIndex++)
        {
            player = playerList[playerIndex].GetComponent<PlayerController>().GetPlayer();
            player.playerDeck.Remove(player.currentCard);
        }

        player = playerList[winnerIndex].GetComponent<PlayerController>().GetPlayer();
        player.playerDeck.AddRange(playerActiveCards);


    }


    private void prepNextMove() {
        int playerIndex = 0;
        PlayerController player;

        playerActiveCards.RemoveRange(0, playerActiveCards.Count);
        //Set the active cards for all players
        for (playerIndex = 0; playerIndex < 4; playerIndex++)
        {
            player = playerList[playerIndex].GetComponent<PlayerController>();
            player.GetPlayer().currentCard = player.GetPlayer().playerDeck[player.GetPlayer().playerDeck.Count - 1];
            playerActiveCards.Add(player.GetPlayer().currentCard);
        }

    }

    private bool hasGameEnded()
    {
        return false;
    }

}
