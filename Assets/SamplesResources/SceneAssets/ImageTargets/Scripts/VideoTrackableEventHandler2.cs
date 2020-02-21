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
        
        VideoPlayerManager.Instance.playVideo(this.gameObject);

        base.OnTrackingFound();

    }

    protected override void OnTrackingLost()
    {
        VideoPlayerManager.Instance.pauseVideo();
        base.OnTrackingLost();
    }
}
