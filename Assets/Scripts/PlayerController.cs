using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Player player;

    public GameController gameController;
	// Use this for initialization
	void Start () {
        player = new Player();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void beginRound(int cardItemIndex) {
        gameController.gameRound(cardItemIndex);
    }

    public Player GetPlayer() {
        return player;
    }
}
