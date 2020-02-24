using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GnomeTrackableEventHandler2 : DefaultTrackableEventHandler {

    public GameObject gnome;

    private AudioSource myAudio;

    private bool audioStart = true;

    protected override void Start()
    {
        myAudio = gnome.GetComponent<AudioSource>();

        base.Start();
    }

    protected override void OnTrackingFound()
    {
        if (!gnome.GetComponent<Gnome>().isPlaying)
        {
            if (audioStart)
            {
                myAudio.Play(0);
                audioStart = false;
            }
            else
                myAudio.UnPause();

            gnome.GetComponent<Gnome>().isPlaying = true;
        }

        base.OnTrackingFound();
    }

    protected override void OnTrackingLost()
    {
        if (gnome.GetComponent<Gnome>().isPlaying)
        {
            myAudio.Pause();
            gnome.GetComponent<Gnome>().isPlaying = false;
        }

        base.OnTrackingLost();
    }
}
