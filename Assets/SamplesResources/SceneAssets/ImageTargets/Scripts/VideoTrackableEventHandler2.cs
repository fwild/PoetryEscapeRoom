using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoTrackableEventHandler2 : DefaultTrackableEventHandler {

    public VideoPlayer video;

    protected override void Start()
    {
        base.Start();

        ///video = GetComponentInChildren<VideoPlayer>();
    }

    protected override void OnTrackingFound()
    {

        //GetComponentInChildren<VideoPlayer>().Play();
        video.Play();
        base.OnTrackingFound();

    }

    protected override void OnTrackingLost()
    {
        //GetComponentInChildren<VideoPlayer>().Pause();
        video.Pause();

        base.OnTrackingLost();
    }
}
