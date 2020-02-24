﻿using HoloToolkit.Unity;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class wordComposer : Singleton<wordComposer> {

    public Color HighlightColor = Color.red;
    public Color NormalColor = Color.white;

    public TextMesh myText;

    private List<GameObject> syllableObjects;

    private LineRenderer theWordLine;
    private List<Vector3> LinePositions;

    private List<string> mySyllables;
    private string[][] defMatrix = new string[27][];

    public delegate void CallBackStack(string syl);
    public CallBackStack onSyllableSelected; // register to this callback stack in order to receive notifications of gazelock on syllables

    public void Start()
    {

        defMatrix[0] = new string[3] { "preconsciousing", "Preconsciousing", "The material used to construct knowledge and make it sensible to consciousness" };
        defMatrix[1] = new string[3] { "predreaming", "Predreaming", "The state before we begin to dream; the residual stuff of that state" };
        defMatrix[2] = new string[3] { "prebodying", "Prebodying", "The process of imagining life (and death) in the body we will come to inhabit" };
        defMatrix[3] = new string[3] { "transconsciousing", "Transconsciousing", "Psychic vehicle by which we move from different self states" };
        defMatrix[4] = new string[3] { "transdreaming", "Transdreaming", "That moment when you find yourself acting in another's dream (or nightmare)" };
        defMatrix[5] = new string[3] { "transbodying", "Transbodying", "To enter your own changed body after a long time somewhere far away" };
        defMatrix[6] = new string[3] { "unconsciousing", "Unconsciousing", "To deliberately and intentionally surrender consciousness to other parts of your self" };
        defMatrix[7] = new string[3] { "un dreaming", "Undreaming", "To peel away the utopian and out-of-reach nature of your desires in order to make them real" };
        defMatrix[8] = new string[3] { "unbodying", "Unbodying", "The process by which capitalistic forces reduce you to the data you generate" };
        defMatrix[9] = new string[3] { "preconsciousectomy", "Preconsciousectomy", "Avoiding true knowledge (and responsibility); the numb, ghostlike sensation thereafter" };
        defMatrix[10] = new string[3] { "predreamectomy", "Predreamectomy", "" };
        defMatrix[11] = new string[3] { "prebodyectomy", "Prebodyectomy", "" };
        defMatrix[12] = new string[3] { "transconsciousectomy", "Transconsciousectomy", "" };
        defMatrix[13] = new string[3] { "transdreamectomy", "Transdreamectomy", "" };
        defMatrix[14] = new string[3] { "transbodyectomy", "Transbodyectomy", "" };
        defMatrix[15] = new string[3] { "unconsciousectomy", "Unconsciousectomy", "" };
        defMatrix[16] = new string[3] { "un dreamectomy", "Undreamectomy", "" };
        defMatrix[17] = new string[3] { "unbodyectomy", "Unbodyectomy", "" };
        defMatrix[18] = new string[3] { "preconsciously", "Preconsciously", "" };
        defMatrix[19] = new string[3] { "predreamly", "Predreamly", "Like the delicate half-world before we fall into a dream. See: Hypnogogia, hypnogogic" };
        defMatrix[20] = new string[3] { "prebodyly", "Prebodily", "" };
        defMatrix[21] = new string[3] { "transconsciously", "Transconsciously", "To act in a way in which you are linked to the minds and thoughts of others.See: empathy, attachment, solidarity" };
        defMatrix[22] = new string[3] { "transdreamly", "Transdreamly", "The way the world becomes the moment you realise you are living according to deep inner principles" };
        defMatrix[23] = new string[3] { "transbodyly", "Transbodily", "" };
        defMatrix[24] = new string[3] { "unconsciously", "Unconsciously", "The manner in which we are expected to go about the world: with deliberate unawareness of power, class and history" };
        defMatrix[25] = new string[3] { "undreamly", "Undreamly", "" };
        defMatrix[26] = new string[3] { "unbodyly", "Unbodily", "" };

        if (!theWordLine)
        {
            Debug.Log("ADDDING LINE RENDERERD FOR WORDCOMPOSER");
            theWordLine = this.gameObject.AddComponent<LineRenderer>();
        }

    }

    public void SyllableSelected( string syl )
    {
        AddSyllable( syl );
        onSyllableSelected?.Invoke( syl );
    }

    public void AddLinePosition( Vector3 position )
    {
        LinePositions.Add(position);
    }

    public void AddSyllable(string syl)
    {
        mySyllables.Add(syl);
    }

    public void DisplayFullWord()
    {

        string concatSyllables = "";
        foreach(string theSyl in mySyllables)
        {
            concatSyllables += theSyl;
        }
        Debug.Log("Compund created: " + concatSyllables);

        int i = 0;
        while (i < 27)
        {
            if ( defMatrix[i][0] == concatSyllables )
            {
                break;
            }
            i++;
        }
        if (i>26)
        {
            myText.text = "Error: could not find compound " + concatSyllables;
        } else
        {
            myText.text = defMatrix[i][1] + ": " + defMatrix[i][2];
        }
    }

    public void DrawLine()
    {

        theWordLine.material = new Material(Shader.Find("Sprites/Default"));
        theWordLine.widthMultiplier = 0.2f;
        theWordLine.positionCount = 2;

        // A simple 2 color gradient with a fixed alpha of 1.0f.
        float alpha = 1.0f;
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(Color.red, 0.0f), new GradientColorKey(Color.yellow, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
        );
        theWordLine.colorGradient = gradient;

        int i = 0;
        foreach (Vector3 lp in LinePositions)
        {
            theWordLine.SetPosition(i, lp);
            i++;
        }

    }

    protected wordComposer() {
        //Debug.Log("Initialising wordComposer");
    }

}
