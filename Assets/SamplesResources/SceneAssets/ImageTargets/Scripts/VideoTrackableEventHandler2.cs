using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoTrackableEventHandler2 : DefaultTrackableEventHandler {
    
    public GameObject videoPlane;
    private VideoPlayer videoPlayer;
    private bool isPlaying = false;

    protected override void Start()
    {
        videoPlane.transform.rotation *= Quaternion.Euler(0, 180f, 0);
        videoPlayer = videoPlane.GetComponent<VideoPlayer>();
        base.Start();
    }

    protected override void OnTrackingFound()
    {
        if (!isPlaying)
        {
            isPlaying = true;
            //VideoPlayerManager.Instance.playVideo(videoPlane, this.gameObject);
            videoPlayer.Play();
        } else
        {
            isPlaying = true;
            videoPlayer.Play();
        }
        base.OnTrackingFound();

    }

    protected override void OnTrackingLost()
    {
        if (isPlaying)
        {
            //VideoPlayerManager.Instance.pauseVideo();
            videoPlayer.Pause();
            isPlaying = false;
        }
        base.OnTrackingLost();
    }
}
