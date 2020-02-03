using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wordOutput : MonoBehaviour {

    public WordManager2 wordManager;

    public Text text;

    public List<string> words;
    public List<string> sentences;

	// Use this for initialization
	void Start () {
        sentences = wordManager.sentences;
        words = wordManager.words;


		
	}

	// Update is called once per frame
	void Update () {
		
	}
}
