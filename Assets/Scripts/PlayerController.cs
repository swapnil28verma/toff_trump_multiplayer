using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Player player;


    private void Awake()
    {
        Debug.Log("Awake for Player Controller called");
        player = new Player();
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BeginRound(int cardItemIndex) {
        GameController.gameControllerInstance.gameRound(cardItemIndex);
        Debug.Log("Round Begun at index !!" + cardItemIndex);
    }

    public Player GetPlayer() {
        return player;
    }
}
