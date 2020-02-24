using HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerManager : Singleton<VideoPlayerManager>
{
    

    //public double timecode;
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
            //videoObject = new GameObject();
            //videoObject.transform.parent = target.transform;

            videoPlane = Instantiate(prefab, target.transform.position, target.transform.rotation);
            videoPlane.transform.parent = target.transform;


            //videoObject.AddComponent<MeshRenderer>();
            //videoObject.AddComponent<MeshFilter>();

            //videoObject.GetComponent<MeshFilter>().mesh = CreatePlaneMesh();
            //videoObject.GetComponent<MeshRenderer>().material.shader = Shader.Find("Default-Material");


            //videoPlayer = videoObject.AddComponent<VideoPlayer>();
            videoPlayer = videoPlane.GetComponent<VideoPlayer>();
            videoPlayer.clip = videoClip;
            
            //videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.MaterialOverride;
            //videoPlayer.targetMaterialRenderer = videoObject.GetComponent<MeshRenderer>();
            //videoPlayer.targetMaterialProperty = "_MainTex";

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

    //private Mesh CreatePlaneMesh()
    //{
    //    Mesh m = new Mesh();
    //    m.name = "PlaneMesh";
    //    m.vertices = new Vector3[] {
    //         new Vector3( _width/2f, -_height/2f, 0 ),
    //         new Vector3( -_width/2f, -_height/2f, 0 ),
    //         new Vector3( -_width/2f, _height/2f, 0 ),
    //         new Vector3( _width/2f, _height/2f, 0 )
    //     };
    //    m.uv = new Vector2[] {
    //         new Vector2 (1, 0),
    //         new Vector2 (0, 0),
    //         new Vector2 (0, 1),
    //         new Vector2 (1, 1)
    //     };
    //    m.triangles = new int[] { 0, 1, 2, 0, 2, 3 };
    //    m.RecalculateNormals();

    //    return m;
    //}



    protected VideoPlayerManager()
    {

    }
}
