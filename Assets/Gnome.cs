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
    public Camera arCamera;
    //private TextMesh textComponent;

    public Text consoleLog;


    private int textDelay = 20; // lower is better
    
    
	void Start () {
        //consoleLog.text += "gnome.cs start routine begin\n";

        //words = new WordManager2();
        words = this.GetComponent<WordManager2>();

        //consoleLog.text += "got component word manager instance\n";
        
        audio = this.GetComponent<AudioSource>();

        audio.clip = audioClip;
        audioDuration = audio.clip.length;

        currentCharacterCount = 0;
        tickCount = 0;
        currentWord = 0;

        isPlaying = false;

        //consoleLog.text += "gnome.cs start routine end\n";
	}
	
	// Update is called once per frame
	void Update () {

        //consoleLog.text += "isplaying? " + isPlaying;

        if (isPlaying)
        {
            tickCount++;
        }

        //consoleLog.text += "test\n";
        consoleLog.text += "tc =" + tickCount + ", wc=" + currentWord + ", w=" + words.words.Count + "\n";

        //Debug.Log("tc =" + tickCount + ", wc=" + currentWord + ", w=" + words.words.Count + "\n");

        //Debug.Log("wc: " + words.words.Count);
        //Debug.Log("sc: " + words.sentences.Count);

        //Debug.Log("words: " + words.words.Count);

        if ((tickCount > textDelay) && (currentWord  < words.words.Count))
        {

            consoleLog.text += "generating new word inside conditions\n";

            tickCount = 0;

            //Instantiate(prefab, this.transform.position + 0.5f * Vector3.down, this.transform.rotation);
            //GameObject wordObject = Instantiate(prefab, transform.position, Quaternion.identity, transform.parent);
            GameObject wordObject = Instantiate(prefab, this.transform.position + 0.5f * Vector3.down, this.transform.rotation);
            Canvas cancasComponent = wordObject.GetComponentInParent<Canvas>();

            cancasComponent.worldCamera = arCamera;


            TextMesh textComponent = wordObject.GetComponentInChildren<TextMesh>();

            textComponent.text = words.words[currentWord];

            //textComponent = prefab.GetComponent<TextMesh>();
            //TextMesh textComponent = prefab.GetComponentInChildren<TextMesh>();


            //textComponent.text = words.words[currentWord];

            // send to billboard in hololens for debugging purposes
            //consoleLog.text += "word = "+ textComponent.text;

            currentWord++;


        }
	}
}
