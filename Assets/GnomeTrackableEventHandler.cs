using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class GnomeTrackableEventHandler : DefaultTrackableEventHandler {

    private Gnome myGnome;

    public Text consoleLog;

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
        consoleLog.text += "ontrackingfound running.\n";

        if (!myGnome.isPlaying)
        {
            myGnome.audio.Play(0);
            myGnome.isPlaying = true;
            consoleLog.text += "gnome set to play audio\n";
        }
    }
    
}
