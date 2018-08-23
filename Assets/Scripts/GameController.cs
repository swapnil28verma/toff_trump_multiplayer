using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    List<GameObject> playerList;
    List<Card> playerActiveCards;

    int winnerIndex = 0;
    // Use this for initialization
    void Start()
    {

        playerActiveCards = new List<Card>();
        //Get the JSON data from the json file
        getJsonData();

        //Read and use the JSON data for init
        parseJsonData();
    }

    public void getJsonData() {
        
    }

    public void parseJsonData() {
        
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

            cardItem = card.items[cardItemIndex];
            if(cardItem.fieldValue > higestValue) {
                higestValue = cardItem.fieldValue;
                winnerIndex = index;
            }
            index++;
        }
    }

    private void refreshDecksAfterRound()
    {
        foreach(Card card in playerActiveCards){
            playerList[winnerIndex].GetComponent<PlayerController>().GetPlayer().playerDeck.Add(card);            
        }

    }

    private void prepNextMove() {
        
    }

    private bool hasGameEnded()
    {
        return false;
    }

}
