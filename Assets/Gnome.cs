﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gnome : MonoBehaviour {

    private int currentWord;
    private int tickCount;

    //private int currentCharacterCount;
    //private int totalCharacterCount;


    public AudioSource myAudio;
    public AudioClip audioClip;
    //private float audioDuration;

    public bool isPlaying;
    
    private WordManager2 words;

    public GameObject prefab;
    public Camera arCamera;

    public Text consoleLog;

    public GameObject viewFinder;
    //private LineRenderer lr;
    private Outline ol;
    private LineRenderer lr;
    Color lrC1 = Color.white;
    Color lrC2 = new Color(1, 1, 1, 0);

    private int textDelay = 17; // lower is better 20 was really quite good..

    void Start()
    {
        //words = this.GetComponent<WordManager2>();        
        words = GameObject.Find("Word Manager").GetComponent<WordManager2>();
        myAudio = this.GetComponent<AudioSource>();

        if (!viewFinder.GetComponent<LineRenderer>())
        {
            lr = viewFinder.AddComponent<LineRenderer>() as LineRenderer;
            lr.positionCount = 5;

            lr.material = new Material(Shader.Find("Sprites/Default"));
            lr.widthMultiplier = 0.002f;
            float alpha = 1.0f;
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new GradientColorKey[] { new GradientColorKey(lrC1, 0.0f), new GradientColorKey(lrC2, 1.0f) },
                new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
            );
            lr.colorGradient = gradient;

            //DrawViewFinder();
        } else
        {
            lr = viewFinder.GetComponent<LineRenderer>();

        }

        //lr.SetPosition(1, Screen.safeArea)
        //ol = this.transform.parent.gameObject.AddComponent<Outline>();
        //ol.effectColor = Color.red;

        myAudio.clip = audioClip;
        //audioDuration = myAudio.clip.length;

        //currentCharacterCount = 0;
        tickCount = 0;
        currentWord = 0;

        isPlaying = false;

        //consoleLog.text += "GnomeScript - Start routine complete, initialised variables."; //Hololens in game
        Debug.Log("GnomeScript - Start routine complete, initialised variables."); //VS debug
    }
    void DrawViewFinder()
    {

            float xfac = 0.8f * 0.125f;
            float yfac = 0.5f * 0.125f;
            float zfac = 0.5f;//3f;
            lr.SetPosition(0, arCamera.transform.position + xfac * Vector3.left + yfac * Vector3.up + zfac * Vector3.forward);
            lr.SetPosition(1, arCamera.transform.position + xfac * Vector3.right + yfac * Vector3.up + zfac * Vector3.forward);
            lr.SetPosition(3, arCamera.transform.position + xfac * Vector3.left + yfac * Vector3.down + zfac * Vector3.forward);
            lr.SetPosition(2, arCamera.transform.position + xfac * Vector3.right + yfac * Vector3.down + zfac * Vector3.forward);
            lr.SetPosition(4, arCamera.transform.position + xfac * Vector3.left + yfac * Vector3.up + zfac * Vector3.forward);

    }
    // Update is called once per frame
    void Update () {
        DrawViewFinder();
        if (isPlaying)
        {
            tickCount++;

            //if (!ol.enabled) ol.enabled = true;

        } else
        {
            //if (ol.enabled) ol.enabled = false;
        }

        if ((tickCount > textDelay) && (currentWord  < words.words.Count))
        {
            tickCount = 0;

            //old way before 01:26 04/02/2020
            //GameObject wordObject = Instantiate(prefab, this.transform.position + 0.5f * Vector3.down, this.transform.rotation);
            //Canvas canvasComponent = wordObject.GetComponentInParent<Canvas>();

            //canvasComponent.worldCamera = arCamera;

            //TextMesh textComponent = wordObject.GetComponentInChildren<TextMesh>();

            GameObject wordObject = Instantiate(prefab, this.transform.position + 0.05f * Vector3.up, this.transform.rotation); // was +0.5f.. a bit too low but okay?
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
