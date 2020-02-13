using HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallBehaviour : MonoBehaviour {

    private Vector3 pos;
    private float speed = 25f;

    public AudioSource myAudio;
    public AudioClip audioClip;

    public Text consoleLog;

    //private Renderer rend;
    private LinePathManager lpmgr;
    public GameObject pathObj;

    Shader transparent, normal;

	// Use this for initialization
	void Start () {
        this.transform.parent.transform.Find("Content").gameObject.SetActive(false);

        //myAudio = this.GetComponent<AudioSource>();
        //rend = this.GetComponent<Renderer>();
        lpmgr = pathObj.GetComponent<LinePathManager>();

        //transparent = Shader.Find("Custom/PortalBallShader");
        //transparent.Equals = 
	}

    //Currently as of 01:44 04.02.2020 this is not working for ballbehaviour or assetbehaviour
    private void OnEnable()
    {
        //WorldAnchorManager.Instance.AnchorStore.Delete(this.gameObject.name);
        //WorldAnchorManager.Instance.RemoveAnchor(this.gameObject);
        //WorldAnchorManager.Instance.AttachAnchor(this.gameObject, this.gameObject.name);
        //this may throw an error when an anchor exists already
    }

    // Update is called once per frame
    void Update () {
        //rotate balls in the air 
        //this.transform.RotateAround(pos, new Vector3(0f, 0f, 0f), 90f * Time.deltaTime);
        //transform.Rotate(Vector3.up * speed * Time.deltaTime);
        //transform.Rotate(GetComponentInParent<GameObject>().transform.position, 20 * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("triggered ballbeh");
        //do something
        //consoleLog.text += "ball ontrigging begin: Activating ball content\n";
        myAudio.clip = audioClip;
        myAudio.Play(0);
        
        //normal = rend.material.shader;
        //rend.material.shader = transparent;

        //this.transform.Find("Content").gameObject.SetActive(true);

        lpmgr.visitAsset(this.gameObject);
        //consoleLog.text += "Ball ontrigger ended\n";
        //Debug.Log("ballbeh ended");

        this.gameObject.SetActive(false); // decative itself


    }

    private void OnTriggerExit(Collider other)
    {
        //consoleLog.text += "Deactivating ball content\n";

        //rend.material.shader = normal;
        //this.transform.Find("Content").gameObject.SetActive(false);
    }
}
