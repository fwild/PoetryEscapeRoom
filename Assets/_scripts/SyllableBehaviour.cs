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

    private bool waitForOutro = false;
    private int outroTickCounter = 0;
    private int outroTickDuration = 200;


    public void InitSyllable( string syl, GameObject myGO )
    {

        wMatrix[0] = new string[3] { "pre", "trans", "un" };
        wMatrix[1] = new string[3] { "conscious", "dream", "body" };
        wMatrix[2] = new string[3] { "ing", "ectomy", "ly" };

        mySyllable = syl;
        myWordObject = myGO;
        //Debug.Log("pos at init: " + myWordObject.transform.position);

        UpdateColor();

        if (!myWordObject.GetComponent<LineRenderer>()) myWordObject.AddComponent<LineRenderer>();
        lr = myWordObject.GetComponent<LineRenderer>();
        lr.positionCount = 0;

    }

    public void UpdateColor()
    {

        // adapt color
        TextMesh tm = myWordObject.GetComponent<TextMesh>();
        if (Phase < 2 && wMatrix[Phase].Contains(mySyllable))
        {
            tm.color = WordComposer.Instance.HighlightColor;
        }
        else
        {
            tm.color = WordComposer.Instance.NormalColor;
        }

    }

	// Use this for initialization
	void Start () {
        WordComposer.Instance.onSyllableSelected += HandleSyllableSelection;
    }

    // Update is called once per frame
    void Update () {

		if (Phase == 1 || Phase == 2)
        {
            //DrawLine(Camera.main.transform.position + 0.3f*Vector3.forward);
        }

        if (gazedUpon)
        {
            gazeTickCounter++;
            if (gazeTickCounter > gazeDuration)
            {
                // gazeTrigger
                Debug.Log("GAZE TRIGGERED " + mySyllable);
                if (wMatrix[Phase].Contains(mySyllable))
                {
                    WordComposer.Instance.AddLinePosition(myWordObject.transform.position);
                    WordComposer.Instance.SyllableSelected(mySyllable);
                } else
                {
                    Debug.Log("wrong phase "+Phase+" for " + mySyllable +" selection");
                }
                gazedUpon = false;

            } else if ( (gazeTickCounter % 20) == 0 ) 
            {
                Debug.Log(".");
            }
        }

        if (waitForOutro)
        {
            outroTickCounter++;
            if (outroTickCounter > outroTickDuration)
            {
                WordComposer.Instance.displayOutro();
                waitForOutro = false;
            }
        }

    }


    public void HandleSyllableSelection( string syl )
    {
        Debug.Log("Phase "+Phase+": a syllable was gaze selected " + syl + " and I am " + mySyllable);

        if (syl == mySyllable)
        {
            //Debug.Log("That's me :)");
            if (Phase == 2)
            {
                //Debug.Log("drawing line");
                WordComposer.Instance.DrawLine();
                //Debug.Log("showing definition");
                WordComposer.Instance.DisplayFullWord();
            } else
            {
                startPos = myWordObject.transform.position;
            }
        }

        if (Phase < 2)
        {
            Phase++;
        } else
        {
            waitForOutro = true;
        }
        UpdateColor();

    }

    public void DrawLine(Vector3 currentPos)
    {

        lr.material = new Material(Shader.Find("Sprites/Default"));
        lr.widthMultiplier = 0.005f;
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

    void Destroy()
    {
        WordComposer.Instance.onSyllableSelected -= HandleSyllableSelection;
    }
}
