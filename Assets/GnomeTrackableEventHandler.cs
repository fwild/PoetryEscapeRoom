using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class GnomeTrackableEventHandler : DefaultTrackableEventHandler {

    private Gnome myGnome;

    public Text consoleLog;

    private bool audioStart = true;

    //private bool isPlaying = false;
    

    protected override void Start()
    {
        myGnome = this.GetComponentInChildren<Gnome>();
        
        consoleLog.text += "started gnome trackable start routine\n";

        base.Start();
    }

    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        consoleLog.text += "Tracking of target found\n";

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
            consoleLog.text += "Gnome audio start playing\n";
        }
    }

    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
        consoleLog.text += "Tracking of Target Lost\n";

        if (myGnome.isPlaying)
        {
            myGnome.audio.Pause();
            myGnome.isPlaying = false;
            consoleLog.text += "Gnome Audio has stopped\n";
        }

    }

}
