using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardController : MonoBehaviour {
    public PlayerController playerController;
    public int fieldIndex = 0;

    // Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void  fieldClickHandler() {
        
    }

    public void OnMouseDown()
    {
        Debug.Log("Clicked" + fieldIndex);

        //playerController.beginRound(1);

    }
}
