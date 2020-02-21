using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
        showInstruction("Unbody:\n Air-tap or say 'start' to begin...");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Intro()
    {
        showInstruction("Stand where the body lies...");
    }

    

    public void showInstruction(string message)
    {
        this.GetComponent<TextMesh>().text = message;
    }
}
