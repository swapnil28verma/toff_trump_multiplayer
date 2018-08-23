using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tempScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void displayText(string fieldValue) {
        Text textObject = GetComponent<Text>();

        textObject.text = fieldValue;

        textObject.enabled = !textObject.isActiveAndEnabled;
    }
}
