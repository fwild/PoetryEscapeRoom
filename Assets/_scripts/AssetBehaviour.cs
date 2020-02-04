using HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssetBehaviour : MonoBehaviour {
    
    private AudioSource audio;
    public AudioClip audioClip;

    public Text consoleLog;
    private LinePathManager lpmgr;

    // Use this for initialization
    void Start()
    {
        audio = this.GetComponent<AudioSource>();
        lpmgr = GameObject.Find("Paths").GetComponent<LinePathManager>();

    }

    // Update is called once per frame
    void Update()
    {
        //rotate balls in the air 
        //this.transform.RotateAround(pos, new Vector3(0f, 0f, 0f), 90f * Time.deltaTime);
        //transform.Rotate(Vector3.up * speed * Time.deltaTime);
        //transform.Rotate(GetComponentInParent<GameObject>().transform.position, 20 * Time.deltaTime, 0);
    }

    private void OnEnable()
    {
        WorldAnchorManager.Instance.AnchorStore.Delete(this.gameObject.name);
        WorldAnchorManager.Instance.RemoveAnchor(this.gameObject);
        WorldAnchorManager.Instance.AttachAnchor(this.gameObject, this.gameObject.name);
        //this may throw an error when an anchor exists already
    }

    private void OnTriggerEnter(Collider other)
    {
        //do something
        audio.clip = audioClip;
        audio.Play(0);

        consoleLog.text += "Activating asset audio\n";

        lpmgr.visitAsset(this.gameObject);

    }

    //private void OnTriggerExit(Collider other)
    //{

    //}
}
