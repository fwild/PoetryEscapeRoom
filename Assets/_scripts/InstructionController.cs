﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionController : MonoBehaviour {

    public GameObject theText;
    private TextMesh theTextMesh;
    public GameObject theLine;
    private LineRenderer lr;
    public Camera arCamera;

    // Use this for initialization
    void Start () {

        theTextMesh = theText.GetComponent<TextMesh>();
        lr = theLine.GetComponent<LineRenderer>();

        showInstruction("UNBODY\n Say 'begin' to start...");
        DrawViewFinder();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Clear()
    {
        showInstruction("");
    }

    public void Intro()
    {
        showInstruction("Stand where the body lies...");
    }

    public void Reset()
    {
        showInstruction("");
        // this is where all the reset instruction would go.
        // unfortunately we cannot simply reload the scene, as this will not work for Vuforia,
        // so we have to remove / reset everything by hand
    }

    public void setTextSize(int theSize)
    {
        theTextMesh.fontSize = theSize;
    }

    public void showInstruction(string message)
    {
        if (message == "")
        {
            theLine.SetActive(false);
            theTextMesh.text = message;
            theText.SetActive(false);
        }
        else
        {
            theLine.SetActive(true);
            theTextMesh.text = message;
            theText.SetActive(true);
        }
    }

    void DrawViewFinder()
    {
        lr.useWorldSpace = false;
        lr.positionCount = 5;

        lr.material = new Material(Shader.Find("Sprites/Default"));
        lr.widthMultiplier = 0.002f;
        //float alpha = 1.0f;
        //Gradient gradient = new Gradient();
        //gradient.SetKeys(
        //    new GradientColorKey[] { new GradientColorKey(lrC1, 0.0f), new GradientColorKey(lrC2, 1.0f) },
        //    new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
        //);
        //lr.colorGradient = gradient;

        float xfac = 40f; // 0.8f * 0.125f;
        float yfac = 12f; // 0.5f * 0.125f;
        float zfac = 0.3f; //0.3f;

        lr.SetPosition(0, theLine.transform.position + xfac * Vector3.left + 22.0f * Camera.main.transform.right + yfac * Vector3.up - 5f * Vector3.up + zfac * Camera.main.transform.forward);
        lr.SetPosition(1, theLine.transform.position + xfac * Vector3.right + 20.0f * Camera.main.transform.right + yfac * Vector3.up - 5f * Vector3.up + zfac * Camera.main.transform.forward);
        lr.SetPosition(2, theLine.transform.position + xfac * Vector3.right + 20.0f * Camera.main.transform.right + yfac * Vector3.down - 5f * Vector3.up + zfac * Camera.main.transform.forward);
        lr.SetPosition(3, theLine.transform.position + xfac * Vector3.left + 22.0f * Camera.main.transform.right + yfac * Vector3.down - 5f * Vector3.up + zfac * Camera.main.transform.forward);
        lr.SetPosition(4, theLine.transform.position + xfac * Vector3.left + 22.0f * Camera.main.transform.right + yfac * Vector3.up - 5f * Vector3.up + zfac * Camera.main.transform.forward);

    }

}
