using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using HoloToolkit.Unity.InputModule;

public class SyllableBehaviour : MonoBehaviour, IFocusable {

    private string mySyllable;
    private int Phase = 0;

    private string[][] wMatrix = new string[3][];
    private GameObject myWordObject;

    private LineRenderer lr;
    private Vector3 startPos;

    private bool gazedUpon;
    private int gazeTickCounter = 0;
    private int gazeDuration = 100;

    public void InitSyllable( string syl, GameObject myGO )
    {

        wMatrix[0] = new string[3] { "pre", "trans", "un" };
        wMatrix[1] = new string[3] { "conscious", "dream", "body" };
        wMatrix[2] = new string[3] { "ing", "ectomy", "ly" };

        mySyllable = syl;
        myWordObject = myGO;

        UpdateColor();

        lr = myWordObject.AddComponent<LineRenderer>();

    }

    public void UpdateColor()
    {

        // adapt color
        TextMesh tm = myWordObject.GetComponent<TextMesh>();
        if (wMatrix[Phase].Contains(mySyllable))
        {
            tm.color = wordComposer.Instance.HighlightColor;
        }
        else
        {
            tm.color = wordComposer.Instance.NormalColor;
        }

    }

	// Use this for initialization
	void Start () {
        wordComposer.Instance.onSyllableSelected += HandleSyllableSelection;
	}
	
	// Update is called once per frame
	void Update () {

		if (Phase == 1 || Phase == 2)
        {
            DrawLine(Camera.main.transform.position + Vector3.forward);
        }

        if (gazedUpon)
        {
            gazeTickCounter++;
            if (gazeTickCounter > gazeDuration)
            {
                // gazeTrigger
                wordComposer.Instance.SyllableSelected(mySyllable);
            } else if ( (gazeTickCounter % 20) == 0 ) 
            {
                Debug.Log(".");
            }
        }

	}


    void HandleSyllableSelection( string syl )
    {
        Debug.Log("a syllable was gaze selected " + syl + " and I am " + mySyllable);

        if (syl == mySyllable)
        {
            wordComposer.Instance.AddLinePosition(myWordObject.transform.position);
            wordComposer.Instance.AddSyllable(mySyllable);
            if (Phase == 2)
            {
                wordComposer.Instance.DrawLine();
                wordComposer.Instance.DisplayFullWord();
            } else
            {
                startPos = myWordObject.transform.position;
            }
        }

        Phase++;
        UpdateColor();

    }

    // attach new component script for gazecursor selection
    // and highlighting
    // and line connections
    // at the end of each selection sequence, output to instructionPanel the full word and def
    // when internal counter shows three full compound words were created, stop and display outro on instrpanel


    public void DrawLine(Vector3 currentPos)
    {

        lr.material = new Material(Shader.Find("Sprites/Default"));
        lr.widthMultiplier = 0.05f;
        lr.positionCount = 2;

        lr.SetPosition(0, startPos);
        lr.SetPosition(1, currentPos);

    }

    public void OnFocusEnter()
    {
        gazedUpon = true;
    }

    public void OnFocusExit()
    {
        gazedUpon = false;
    }
}
