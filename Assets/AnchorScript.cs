using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;
using UnityEngine.UI;

public class AnchorScript : MonoBehaviour {

    public WorldAnchorManager manager;
    public Text textLog;

    private void Start()
    {
        manager.RemoveAllAnchors();
        //manager.AttachAnchor(this.gameObject);
        //anchorObject();
    }

    public void anchorObject()
    {
        textLog.text += "AC: attempting to anchor the object\n";

        manager.AttachAnchor(this.gameObject);
        this.gameObject.GetComponent<Renderer>().material.color = Color.green;
    }

    public void unanchorObject()
    {
        manager.RemoveAnchor(this.gameObject);
        this.gameObject.GetComponent<Renderer>().material.color = Color.white;
    }
}
