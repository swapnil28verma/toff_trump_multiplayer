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
        Debug.Log("Start for Player Controller called");
        player = new Player();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BeginRound(int cardItemIndex) {
        //gameController.gameRound(cardItemIndex);
    }

    public Player GetPlayer() {
        return player;
    }
}
