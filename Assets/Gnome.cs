using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gnome : MonoBehaviour {

    private int currentWord;
    private int tickCount;

    //private int currentCharacterCount;
    //private int totalCharacterCount;


    public AudioSource audio;
    public AudioClip audioClip;
    //private float audioDuration;

    public bool isPlaying;
    
    private WordManager2 words;

    public GameObject prefab;
    //public Camera arCamera;

    public Text consoleLog;


    private int textDelay = 17; // lower is better 20 was really quite good..


    void Start()
    {
        //words = this.GetComponent<WordManager2>();        
        words = GameObject.Find("Word Manager").GetComponent<WordManager2>();
        audio = this.GetComponent<AudioSource>();

        audio.clip = audioClip;
        //audioDuration = audio.clip.length;

        //currentCharacterCount = 0;
        tickCount = 0;
        currentWord = 0;

        isPlaying = false;

        //consoleLog.text += "GnomeScript - Start routine complete, initialised variables."; //Hololens in game
        Debug.Log("GnomeScript - Start routine complete, initialised variables."); //VS debug
    }

    // Update is called once per frame
    void Update () {
        if (isPlaying)
            tickCount++;

        if ((tickCount > textDelay) && (currentWord  < words.words.Count))
        {
            tickCount = 0;


            //old way before 01:26 04/02/2020
            //GameObject wordObject = Instantiate(prefab, this.transform.position + 0.5f * Vector3.down, this.transform.rotation);
            //Canvas canvasComponent = wordObject.GetComponentInParent<Canvas>();

            //canvasComponent.worldCamera = arCamera;

            //TextMesh textComponent = wordObject.GetComponentInChildren<TextMesh>();

            GameObject wordObject = Instantiate(prefab, this.transform.position + 0.1f * Vector3.down, this.transform.rotation); // was +0.5f.. a bit too low but okay?
            TextMesh textComponent = wordObject.GetComponent<TextMesh>();
            

            textComponent.text = words.words[currentWord];
            
            currentWord++;
        }
	}

    public void checkPlaying()
    {
        Debug.Log("IsPlaying? " + isPlaying); //VS debug
        //consoleLog.text += "isplaying? " + isPlaying + "\n"; //Hololens in game
    }

    public void checkWords()
    {
        Debug.Log("tc =" + tickCount + ", wc=" + currentWord + ", w=" + words.words.Count + "\n"); //VS debug
        //consoleLog.text += "tc =" + tickCount + ", wc=" + currentWord + ", w=" + words.words.Count + "\n"; //Hololens in game
    }
}
