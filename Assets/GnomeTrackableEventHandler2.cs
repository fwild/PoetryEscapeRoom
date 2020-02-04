using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GnomeTrackableEventHandler2 : DefaultTrackableEventHandler {

    public GameObject gnome;

    private AudioSource audio;

    private bool audioStart = true;

    protected override void Start()
    {
        audio = gnome.GetComponent<AudioSource>();

        base.Start();
    }

    protected override void OnTrackingFound()
    {
        if (!gnome.GetComponent<Gnome>().isPlaying)
        {
            if (audioStart)
            {
                audio.Play(0);
                audioStart = false;
            }
            else
                audio.UnPause();

            gnome.GetComponent<Gnome>().isPlaying = true;
        }

        base.OnTrackingFound();
    }

    protected override void OnTrackingLost()
    {
        if (gnome.GetComponent<Gnome>().isPlaying)
        {
            audio.Pause();
            gnome.GetComponent<Gnome>().isPlaying = false;
        }

        base.OnTrackingLost();
    }
}
