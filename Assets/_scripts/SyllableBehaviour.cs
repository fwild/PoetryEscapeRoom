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
    private int outroTickDuration = 600;

    private Gradient gradient;

    public void InitSyllable( string syl, GameObject myGO )
    {

        wMatrix[0] = new string[3] { "pre", "trans", "un" };
        wMatrix[1] = new string[3] { "conscious", "dream", "body" };
        wMatrix[2] = new string[3] { "ing", "ectomy", "ly" };

        mySyllable = syl;
        myWordObject = myGO;
        //Debug.Log("pos at init: " + myWordObject.transform.position);

        UpdateColor();

    }

    public void UpdateColor()
    {

        // adapt color
        TextMesh tm = myWordObject.GetComponent<TextMesh>();
        if (!waitForOutro && wMatrix[Phase].Contains(mySyllable))
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

        if (!myWordObject.GetComponent<LineRenderer>()) myWordObject.AddComponent<LineRenderer>();
        lr = myWordObject.GetComponent<LineRenderer>();
        lr.positionCount = 0;

        float alpha = 1.0f;
        gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(Color.red, 0.0f), new GradientColorKey(Color.yellow, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 1.0f), new GradientAlphaKey(alpha, 1.0f) }
        );

        lr.useWorldSpace = false;

        lr.material = new Material(Shader.Find("Sprites/Default"));
        lr.widthMultiplier = 0.005f;
        lr.startWidth = 0.005f;
        lr.endWidth = 0.005f;
        lr.colorGradient = gradient;

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

            } else // if ( (gazeTickCounter % 20) == 0 ) 
            {
                myWordObject.GetComponent<TextMesh>().color = gradient.Evaluate( (float)gazeTickCounter / (float)gazeDuration );
                DrawLine(gazeTickCounter);
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

        if (!waitForOutro && syl == mySyllable)
        {
            //Debug.Log("That's me :)");
            if (Phase == 2)
            {
                Debug.Log("drawing line");
                WordComposer.Instance.DrawLine();
                Debug.Log("showing definition");
                WordComposer.Instance.DisplayFullWord();
                waitForOutro = true;
                Debug.Log("Waiting for Outro");
            }
            else
            {
                startPos = myWordObject.transform.position;
            }
        }

        if (Phase < 2)
        {
            Phase++;
        } 
        UpdateColor();

    }

    public static float GetWidth(TextMesh mesh)
    {
        float width = 0;
        foreach (char symbol in mesh.text)
        {
            CharacterInfo info;
            if (mesh.font.GetCharacterInfo(symbol, out info, mesh.fontSize, mesh.fontStyle))
            {
                width += info.advance;
            }
        }
        return width * mesh.characterSize * 0.1f;
    }

    public void DrawLine( int tickCounter )
    {

        //RectTransform rt = (RectTransform)myWordObject;
        //Debug.Log("rect width: "+ GetWidth(myWordObject.GetComponent<TextMesh>()));
        
        lr.positionCount = 2;
        lr.SetPosition(0, new Vector3(0,0,0) );
        lr.SetPosition(1, new Vector3(((float)gazeTickCounter/(float)gazeDuration) * GetWidth(myWordObject.GetComponent<TextMesh>()), 0, 0) );
        //lr.enabled = true;

    }

    public void OnFocusEnter()
    {
        if (wMatrix[Phase].Contains(mySyllable)) gazedUpon = true;
    }

    public void OnFocusExit()
    {
        gazedUpon = false;
        // reset the lr
        gazeTickCounter = 0;
        lr.positionCount = 0;
    }

    void Destroy()
    {
        WordComposer.Instance.onSyllableSelected -= HandleSyllableSelection;
    }
}
