using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class GnomeTrackableEventHandler : DefaultTrackableEventHandler {

    private Gnome myGnome;

    public Text consoleLog; // need this for hololens

    private bool audioStart = true;

    //private bool isPlaying = false;
    

    protected override void Start()
    {
        base.Start();
        Debug.Log("base start script run");


        myGnome = GetComponentInChildren<Gnome>();
        Debug.Log("got the gnome child");
        //myGnome.gameObject.GetComponent<AudioSource>(); // this doesnt work???
        //gnomeSpeaker = myGnome.GetComponent<AudioSource>(); //this is the one that should work but it doesnt? null exception????
        //AudioSource test = myGnome.audio;
        Debug.Log("COMPLETE");


        //consoleLog.text += "started gnome trackable start routine\n";
        //Debug.Log("Started trackable gnome routine\n");

    }

    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();

        //consoleLog.text += "Tracking of target found\n";
        //Debug.Log("found target image\n");

        if (!myGnome.isPlaying)
        {
            if (audioStart)
            {
                myGnome.GetComponent<AudioSource>().Play(0);
                audioStart = false;
            }
            else
                myGnome.GetComponent<AudioSource>().UnPause();
            
            myGnome.isPlaying = true;

            myGnome.checkPlaying();

            Debug.Log("started playing track\n");
            //consoleLog.text += "Gnome audio start playing\n";
        }
    }

    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();

        //consoleLog.text += "Tracking of Target Lost\n";
        //Debug.Log("lost target image\n");

        if (myGnome.isPlaying)
        {
            myGnome.GetComponent<AudioSource>().Pause();
            myGnome.isPlaying = false;

            //Debug.Log("stopped playing audio");
            //consoleLog.text += "Gnome Audio has stopped\n";
        }

    }

}
