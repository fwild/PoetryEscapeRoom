using HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerManager : Singleton<VideoPlayerManager>
{
    
    public bool isPlaying = false;

    public GameObject videoObject;
    public VideoPlayer videoPlayer;

    public VideoClip videoClip;

    public GameObject videoPlane;

    public void playVideo(GameObject prefab, GameObject target)
    {
        
        if (isPlaying)
        {
            if (videoPlayer.transform.parent != target)
            {
                videoPlayer.transform.parent = target.transform;
            }

            videoPlayer.Play();

        } else
        {
            Debug.Log("running else statement playVideo");

            videoPlane = Instantiate(prefab, target.transform.position, target.transform.rotation);
            videoPlane.transform.parent = target.transform;
            
            videoPlayer = videoPlane.GetComponent<VideoPlayer>();
            videoPlayer.clip = videoClip;

            videoPlayer.Play();
            isPlaying = true;
            Debug.Log("ended run of playVideo");
        }

    }

    public void pauseVideo()
    {
        if (isPlaying)
        {
            videoPlayer.Pause();
            
        }
    }
    
    protected VideoPlayerManager()
    {

    }
}
