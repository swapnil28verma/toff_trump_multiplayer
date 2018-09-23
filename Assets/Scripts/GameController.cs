using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class GameController : MonoBehaviour
{

    string pathToJson;
    string jsonString;


    public List<GameObject> playerList;

    List<Card> playerActiveCards;
    CardDeck activeDeck;

    int winnerIndex = 0;
    // Use this for initialization
    void Start()
    {
        Debug.Log("Start for Gamecontroller called");

        playerActiveCards = new List<Card>();

        //Get the JSON data from the json file
        getJsonData();

        //Distribute cards from deck
        distributeCards();

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

        playerIndex = 0;
        playerActiveCards.RemoveRange(0, playerActiveCards.Count);
        //Set Active cards for each player
        for (playerIndex = 0; playerIndex < 4; playerIndex++) {
            player = playerList[playerIndex].GetComponent<PlayerController>();
            player.GetPlayer().currentCard = player.GetPlayer().playerDeck[player.GetPlayer().playerDeck.Count-1];
            playerActiveCards.Add(player.GetPlayer().currentCard);
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
        CardItem cardItem;
        int index = 0;
        int higestValue = 0;

        foreach(Card card in playerActiveCards) {

            //cardItem = card.items[cardItemIndex];
            //if(cardItem.fieldValue > higestValue) {
            //    higestValue = cardItem.fieldValue;
            //    winnerIndex = index;
            //}
            index++;
        }
    }

    private void refreshDecksAfterRound()
    {
        foreach(Card card in playerActiveCards){
            playerList[winnerIndex].GetComponent<PlayerController>().GetPlayer().playerDeck.Add(card);
        }

    }

    public void setActiveCards() {

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
