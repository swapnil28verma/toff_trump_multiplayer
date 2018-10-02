using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardController : MonoBehaviour {
    public PlayerController playerController;
    public int fieldIndex = 0;

    public Text fieldValue;

    // Use this for initialization
	void Start () {
        playerController.GetPlayer().OnValueChange += CardFieldUpdate;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDestroy()
    {
        playerController.GetPlayer().OnValueChange -= CardFieldUpdate;
    }

    public void OnMouseDown()
    {
        playerController.BeginRound(fieldIndex);

    }

    public void CardFieldUpdate() {
        switch(fieldIndex) {
            case 0:
                fieldValue.text = playerController.GetPlayer().currentCard.money;
                break;
            case 1:
                fieldValue.text = playerController.GetPlayer().currentCard.properties;
                break;
            case 2:
                fieldValue.text = playerController.GetPlayer().currentCard.marriages;
                break;
            case 3:
                fieldValue.text = playerController.GetPlayer().currentCard.personalstaf;
                break;
            case 4:
                fieldValue.text = playerController.GetPlayer().currentCard.lackofsense;
                break;

        }
    }
}
