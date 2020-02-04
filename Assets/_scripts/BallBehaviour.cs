using HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallBehaviour : MonoBehaviour {

    private Vector3 pos;
    private float speed = 25f;

    private AudioSource audio;
    public AudioClip audioClip;

    public Text consoleLog;

    private Renderer rend;
    private LinePathManager lpmgr;

    Shader transparent, normal;

	// Use this for initialization
	void Start () {
        audio = this.GetComponent<AudioSource>();
        rend = this.GetComponent<Renderer>();
        lpmgr = GameObject.Find("Paths").GetComponent<LinePathManager>();

        transparent = Shader.Find("Custom/PortalBallShader");
        //transparent.Equals = 
	}

    //Currently as of 01:44 04.02.2020 this is not working for ballbehaviour or assetbehaviour
    //private void OnEnable()
    //{
    //    WorldAnchorManager.Instance.AnchorStore.Delete(this.gameObject.name);
    //    WorldAnchorManager.Instance.RemoveAnchor(this.gameObject);
    //    WorldAnchorManager.Instance.AttachAnchor(this.gameObject, this.gameObject.name);
    //    //this may throw an error when an anchor exists already
    //}

    // Update is called once per frame
    void Update () {
        //rotate balls in the air 
        //this.transform.RotateAround(pos, new Vector3(0f, 0f, 0f), 90f * Time.deltaTime);
        //transform.Rotate(Vector3.up * speed * Time.deltaTime);
        //transform.Rotate(GetComponentInParent<GameObject>().transform.position, 20 * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        //do something
        audio.clip = audioClip;
        audio.Play(0);

        consoleLog.text += "Activating ball content\n";
        
        normal = rend.material.shader;
        rend.material.shader = transparent;
        
        this.transform.Find("Content").gameObject.SetActive(true);

        lpmgr.visitAsset(transform.parent.gameObject);

    }

    private void OnTriggerExit(Collider other)
    {
        consoleLog.text += "Deactivating ball content\n";

        rend.material.shader = normal;
        this.transform.Find("Content").gameObject.SetActive(false);
    }
}
