using HoloToolkit.Unity;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.IO;

public class WordComposer : Singleton<WordComposer> {

    public Color HighlightColor = Color.red;
    public Color NormalColor = Color.white;

    public InstructionController Instr;

    //private List<GameObject> syllableObjects = new List<GameObject>();

    private LineRenderer theWordLine;
    private List<Vector3> LinePositions = new List<Vector3>();

    private List<string> mySyllables = new List<string>();
    private string[][] defMatrix = new string[27][];

    public delegate void CallBackStack(string syl);
    public event CallBackStack onSyllableSelected; // register to this callback stack in order to receive notifications of gazelock on syllables

    public void Start()
    {

        defMatrix[0] = new string[3] { "preconsciousing", "Preconsciousing", "The material used to\nconstruct knowledge and make\nit sensible to consciousness" };
        defMatrix[1] = new string[3] { "predreaming", "Predreaming", "The state before we \nbegin to dream; the \nresidual stuff of that state" };
        defMatrix[2] = new string[3] { "prebodying", "Prebodying", "The process of imagining \nlife (and death) in the \nbody we will come to inhabit" };
        defMatrix[3] = new string[3] { "transconsciousing", "Transconsciousing", "Psychic vehicle by which \nwe move from different self states" };
        defMatrix[4] = new string[3] { "transdreaming", "Transdreaming", "That moment when you find \nyourself acting in another's \ndream (or nightmare)" };
        defMatrix[5] = new string[3] { "transbodying", "Transbodying", "To enter your own changed \nbody after a long time \nsomewhere far away" };
        defMatrix[6] = new string[3] { "unconsciousing", "Unconsciousing", "To deliberately and intentionally \nsurrender consciousness to other \nparts of your self" };
        defMatrix[7] = new string[3] { "undreaming", "Undreaming", "To peel away the utopian and \nout-of-reach nature of your \ndesires in order to make them real" };
        defMatrix[8] = new string[3] { "unbodying", "Unbodying", "The process by which capitalistic \nforces reduce you to the \ndata you generate" };
        defMatrix[9] = new string[3] { "preconsciousectomy", "Preconsciousectomy", "Avoiding true knowledge (and \nresponsibility); the numb, \nghostlike sensation thereafter" };
        defMatrix[10] = new string[3] { "predreamectomy", "Predreamectomy", "Procedure by which you divorce \nyourself from the person you \nwere before you fell asleep" };
        defMatrix[11] = new string[3] { "prebodyectomy", "Prebodyectomy", "A choice a parent can make \nto give birth only to the spirit, \nand not the body, of their child" };
        defMatrix[12] = new string[3] { "transconsciousectomy", "Transconsciousectomy", "The exhilirating jolt when you \nfinally see the world as someone \nelse does and are forever changed" };
        defMatrix[13] = new string[3] { "transdreamectomy", "Transdreamectomy", "A psychic tightrope appears and \nyou are tethered to the dreams of \nsomeone else. You can plunder or contribute." };
        defMatrix[14] = new string[3] { "transbodyectomy", "Transbodyectomy", "To change your body so thoroughly, \nso many times, that there is \nnothing of the original left" };
        defMatrix[15] = new string[3] { "unconsciousectomy", "Unconsciousectomy", "There is always someone in your \nlife who gives you the cold, hard \ntruth about yourself. The feeling once \nthey have done this" };
        defMatrix[16] = new string[3] { "undreamectomy", "Undreamectomy", "To dismiss from the imagination as \nthough never dreamed; to destroy what \nremains of that dream" };
        defMatrix[17] = new string[3] { "unbodyectomy", "Unbodyectomy", "To be deprived of the body, \nnot on your terms" };
        defMatrix[18] = new string[3] { "preconsciously", "Preconsciously", "To act as though surrendered to the \npart of the self that makes decisions before \nwe know we have made them" };
        defMatrix[19] = new string[3] { "predreamly", "Predreamly", "Like the delicate half-world \nbefore we fall into a dream. \nSee: Hypnogogia, hypnogogic" };
        defMatrix[20] = new string[3] { "prebodyly", "Prebodily", "To behave in the manner of \na rule rather than an animal; intelligence \nbefore its confinement in a body" };
        defMatrix[21] = new string[3] { "transconsciously", "Transconsciously", "To act in a way in which you are \nlinked to the minds and thoughts of others.\n See: empathy, attachment, solidarity" };
        defMatrix[22] = new string[3] { "transdreamly", "Transdreamly", "The way the world becomes the moment \nyou realise\n you are living according \nto deep inner principles" };
        defMatrix[23] = new string[3] { "transbodyly", "Transbodily", "Without fear of death; the \nunderstanding that you contain many others \nand others in turn will contain you" };
        defMatrix[24] = new string[3] { "unconsciously", "Unconsciously", "The manner in which we are expected \nto go about the world: with deliberate \nunawareness of power, class and history" };
        defMatrix[25] = new string[3] { "undreamly", "Undreamly", "Without involuntary sensations or \nfree association; fixed and forced" };
        defMatrix[26] = new string[3] { "unbodyly", "Unbodily", "The uncanny sense that you are \nknown or perceived in a way that bypasses \nwhat you know of yourself" };

        //if (!theWordLine)
        //{
        //    theWordLine = this.gameObject.AddComponent<LineRenderer>();
        //}
        theWordLine = this.gameObject.GetComponent<LineRenderer>();
        theWordLine.useWorldSpace = true;

    }

    public void SyllableSelected( string syl )
    {
        AddSyllable(syl);
        onSyllableSelected?.Invoke(syl);
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
        //concatSyllables = "unbodyly";
        Debug.Log("Compound created: " + concatSyllables);

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
            Instr.showInstruction( "Error: could not find compound " + concatSyllables);
        } else
        {
            Instr.setTextSize(32);
            Instr.showInstruction( "\n" + defMatrix[i][1] + ":\n " + defMatrix[i][2]);
        }
    }

    public void DrawLine()
    {

        theWordLine.material = new Material(Shader.Find("Sprites/Default"));
        theWordLine.widthMultiplier = 0.005f;
        theWordLine.positionCount = LinePositions.Count;

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

    public void displayOutro()
    {
        Instr.setTextSize(40);

        Instr.showInstruction( "Please return your smart\n glasses on the way out.\nThank you." );
        GameObject.Find("Phase 3").SetActive(false);
        theWordLine.enabled = false;
    }

    protected WordComposer() {
        //Debug.Log("Initialising wordComposer");
    }

}
