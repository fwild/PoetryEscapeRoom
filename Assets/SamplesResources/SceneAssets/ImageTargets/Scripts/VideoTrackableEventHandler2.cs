using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoTrackableEventHandler2 : DefaultTrackableEventHandler {
    
    public GameObject videoPlane;
    
    protected override void Start()
    {
        base.Start();
    }

    protected override void OnTrackingFound()
    {
        
        VideoPlayerManager.Instance.playVideo(videoPlane, this.gameObject);
        base.OnTrackingFound();

    }

    protected override void OnTrackingLost()
    {
        VideoPlayerManager.Instance.pauseVideo();
        base.OnTrackingLost();
    }
}
