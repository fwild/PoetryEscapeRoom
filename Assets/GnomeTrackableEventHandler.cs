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
        myGnome = this.GetComponentInChildren<Gnome>();

        //consoleLog.text += "started gnome trackable start routine\n";
        //Debug.Log("Started trackable gnome routine\n");

        base.Start();
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
                myGnome.audio.Play(0);
                audioStart = false;
            }
            else
                myGnome.audio.UnPause();
            
            myGnome.isPlaying = true;

            myGnome.checkPlaying();

            //Debug.Log("started playing track\n");
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
            myGnome.audio.Pause();
            myGnome.isPlaying = false;

            //Debug.Log("stopped playing audio");
            //consoleLog.text += "Gnome Audio has stopped\n";
        }

    }

}
