using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gnome : MonoBehaviour {

    private int currentWord;
    private int tickCount;

    private int currentCharacterCount;
    private int totalCharacterCount;


    public AudioSource audio;
    public AudioClip audioClip;
    private float audioDuration;

    public bool isPlaying;

    //public List<string> words;
    private WordManager2 words;

    public GameObject prefab;
    private TextMesh textComponent;

    public Text consoleLog;
    

	// Use this for initialization
	void Start () {
        consoleLog.text += "starting start routine\n";

        words = this.GetComponent<WordManager2>();

        audio = this.GetComponent<AudioSource>();

        audio.clip = audioClip;
        audioDuration = audio.clip.length;

        currentCharacterCount = 0;
        tickCount = 0;
        currentWord = 0;

        consoleLog.text += "stopping start routine\n";
	}
	
	// Update is called once per frame
	void Update () {
        
        if (isPlaying)
        {
            tickCount++;
        }
        consoleLog.text += "tc =" + tickCount + ", wc=" + currentWord + ", w=" + words.words.Count + "\n";

        if ((tickCount > 50) && (currentWord  < words.words.Count))
        {
            consoleLog.text += "generating new word inside conditions\n";

            tickCount = 0;

            Instantiate(prefab, this.transform.position + 0.5f * Vector3.down, this.transform.rotation);

            textComponent = prefab.GetComponent<TextMesh>();

            textComponent.text = words.words[currentWord];

            // send to billboard in hololens for debugging purposes
            consoleLog.text += "word = "+ textComponent.text;

            currentWord++;


        }
	}
}
