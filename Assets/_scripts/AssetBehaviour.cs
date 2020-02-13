using HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssetBehaviour : MonoBehaviour {
    
    public AudioSource myAudio;
    public AudioClip audioClip;

    public Text consoleLog;
    private LinePathManager lpmgr;

    public GameObject pathObj;

    // Use this for initialization
    void Start()
    {
        //myAudio = this.GetComponent<AudioSource>();
        lpmgr = pathObj.GetComponent<LinePathManager>();

    }

    //Currently as of 01:44 04.02.2020 this is not working for ballbehaviour or assetbehaviour
    private void OnEnable()
    {
        //WorldAnchorManager.Instance.AnchorStore.Delete(this.gameObject.name);
        //WorldAnchorManager.Instance.RemoveAnchor(this.gameObject);
        //WorldAnchorManager.Instance.AttachAnchor(this.gameObject, this.gameObject.name);
        //this may throw an error when an anchor exists already
    }

    private void OnTriggerEnter(Collider other)
    {
        //do something
        myAudio.clip = audioClip;
        myAudio.Play(0);

        //consoleLog.text += "Activating asset audio\n";

        lpmgr.visitAsset(this.gameObject);

    }

    //private void OnTriggerExit(Collider other)
    //{

    //}
}
