using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using HoloToolkit.Unity.SpatialMapping;

public class Gnome : MonoBehaviour {

    private int currentWord;
    private int tickCount;

    //private int currentCharacterCount;
    //private int totalCharacterCount;
    public List<GameObject> wordObjects = new List<GameObject>();
    public List<GameObject> syllableObjects = new List<GameObject>();

    public InstructionController Instr;

    public AudioSource myAudio;
    public AudioClip audioClip;
    //private float audioDuration;

    public bool isPlaying;
    
    private WordManager2 words;

    public GameObject prefab;
    public Camera arCamera;

    public Text consoleLog;

    public GameObject viewFinder;
    //private LineRenderer lr;
    private Outline ol;
    private LineRenderer lr;
    Color lrC1 = Color.white;
    Color lrC2 = new Color(1, 1, 1, 0);

    private bool wordComposerStarted = false;
    private int textDelay = 50; // lower is better 20 was really quite good..

    // the index position of the wordObjects used for the wordComposer
    int[] tPos = new int[9] { 10, 20, 30, 40, 50, 60, 70, 80, 90 };

    void Start()
    {
        //words = this.GetComponent<WordManager2>();        
        words = GameObject.Find("Word Manager").GetComponent<WordManager2>();
        myAudio = this.GetComponent<AudioSource>();

        if (!viewFinder.GetComponent<LineRenderer>())
        {
            //lr = viewFinder.AddComponent<LineRenderer>() as LineRenderer;
            //lr.positionCount = 5;

            //lr.material = new Material(Shader.Find("Sprites/Default"));
            //lr.widthMultiplier = 0.002f;
            //float alpha = 1.0f;
            //Gradient gradient = new Gradient();
            //gradient.SetKeys(
            //    new GradientColorKey[] { new GradientColorKey(lrC1, 0.0f), new GradientColorKey(lrC2, 1.0f) },
            //    new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
            //);
            //lr.colorGradient = gradient;

            //DrawViewFinder();
        } else
        {
            //lr = viewFinder.GetComponent<LineRenderer>();
        }

        //lr.SetPosition(1, Screen.safeArea)
        //ol = this.transform.parent.gameObject.AddComponent<Outline>();
        //ol.effectColor = Color.red;

        myAudio.clip = audioClip;
        //audioDuration = myAudio.clip.length;

        //currentCharacterCount = 0;
        tickCount = 0;
        currentWord = 0;

        isPlaying = false;

        //consoleLog.text += "GnomeScript - Start routine complete, initialised variables."; //Hololens in game
        //Debug.Log("GnomeScript - Start routine complete, initialised variables."); //VS debug
    }

    void DrawViewFinder()
    {

            //float xfac = 0.8f * 0.125f;
            //float yfac = 0.5f * 0.125f;
            //float zfac = 0.5f;//3f;
            //lr.SetPosition(0, arCamera.transform.position + xfac * Vector3.left + yfac * Vector3.up + zfac * Vector3.forward);
            //lr.SetPosition(1, arCamera.transform.position + xfac * Vector3.right + yfac * Vector3.up + zfac * Vector3.forward);
            //lr.SetPosition(3, arCamera.transform.position + xfac * Vector3.left + yfac * Vector3.down + zfac * Vector3.forward);
            //lr.SetPosition(2, arCamera.transform.position + xfac * Vector3.right + yfac * Vector3.down + zfac * Vector3.forward);
            //lr.SetPosition(4, arCamera.transform.position + xfac * Vector3.left + yfac * Vector3.up + zfac * Vector3.forward);

    }

    // Update is called once per frame
    void Update () {

        //DrawViewFinder();
        if (isPlaying)
        {
            //tickCount++;
            //if (!ol.enabled) ol.enabled = true;

        } else
        {
            //if (ol.enabled) ol.enabled = false;
        }

        //if ((tickCount > textDelay) && (currentWord  < words.words.Count))
        if ((currentWord < words.words.Count) && (myAudio.time > words.wordOffsets[currentWord]))
        {
            tickCount = 0;

            //old way before 01:26 04/02/2020
            //GameObject wordObject = Instantiate(prefab, this.transform.position + 0.5f * Vector3.down, this.transform.rotation); // 0.05f * Vector3.up
            //Canvas canvasComponent = wordObject.GetComponentInParent<Canvas>();

            //canvasComponent.worldCamera = arCamera;

            //TextMesh textComponent = wordObject.GetComponentInChildren<TextMesh>();

            var HeadPosition = Camera.main.transform.position;
            var GazeDirection = Camera.main.transform.forward;
            Vector3 offSet = 0.05f * Vector3.up; //0.5f * Vector3.down;
            RaycastHit hitInfo;
            GameObject wordObject;

            if (Physics.Raycast(HeadPosition, GazeDirection, out hitInfo, 30.0f, Physics.DefaultRaycastLayers)) // + SpatialMappingManager.SpatialMappingLayerMask
            {
                GameObject focusedObject = hitInfo.collider.gameObject;
                if (focusedObject.transform.parent != null)
                {
                    if (focusedObject.transform.parent.name == "SpatialMapping")
                    {
                        Debug.Log(currentWord + ". Hit the spatial map, placing word");
                        wordObject = Instantiate(prefab, hitInfo.point - 0.01f * GazeDirection, hitInfo.collider.gameObject.transform.parent.gameObject.transform.rotation); // Camera.main.transform.localRotation
                    } else // some other parent, not spatial mesh (= usually another word)
                    {
                        Debug.Log(currentWord + ". Hit some other object " + hitInfo.transform.gameObject.name +" with a parent, placing word at gnomebox instead");
                        //wordObject = Instantiate(prefab, hitInfo.point, hitInfo.collider.gameObject.transform.parent.gameObject.transform.rotation); // Camera.main.transform.localRotation
                        wordObject = Instantiate(prefab, this.transform.position + offSet, this.transform.rotation); // was +0.5f.. a bit too low but okay
                    }

                }
                else // no parent, but still hit something
                {
                    Debug.Log(currentWord + ". Hit some object with no parent " + hitInfo.transform.gameObject.name + ", placing word at position of the object + bit up");
                    wordObject = Instantiate(prefab, this.transform.position + offSet, this.transform.rotation); // was +0.5f.. a bit too low but okay?
                }
            }
            else
            {
                Debug.Log(currentWord + ". Hit nothing, so dropping word at gnomebox position");
                wordObject = Instantiate(prefab, this.transform.position + offSet, this.transform.rotation); // was +0.5f.. a bit too low but okay?
            }

            wordObject.transform.parent = GameObject.Find("Phase 2").transform;
            TextMesh textComponent = wordObject.GetComponent<TextMesh>();     
            textComponent.text = words.words[currentWord];

            wordObjects.Add(wordObject); // add gameobject word to list of words
            
            currentWord++;

            //currentWord = currentWord + 9;
            //myAudio.time = myAudio.time + 2;

        } else
        {
            tickCount++;
            if ( (!wordComposerStarted) && (currentWord >= words.words.Count) && (myAudio.time >= myAudio.clip.length || tickCount > textDelay ))
            {
                Debug.Log("Poem has finished\n");

                for (int e = 0; e < wordObjects.Count; e++)
                {
                    wordObjects[e].SetActive(false);
                }

                int n = 0;
                int r = 0;

                for (int e = 0; e < 9; e++)
                {
                    string[] tWords = new string[9] { "pre", "trans", "un", "body", "conscious", "dream", "ectomy", "ly", "ing" };

                    r++;
                    GameObject sylOb = Instantiate(prefab, Camera.main.transform.position + (r % 3) * 0.75f * Camera.main.transform.forward + 0.05f * Camera.main.transform.up + ((r / 3) * 0.5f * Camera.main.transform.right - 0.25f * Camera.main.transform.right), this.transform.rotation);
                    syllableObjects.Add( sylOb );
                    sylOb.GetComponent<TextMesh>().text = tWords[n];
                    sylOb.AddComponent<SyllableBehaviour>();
                    sylOb.GetComponent<SyllableBehaviour>().InitSyllable(tWords[n], sylOb);
                    Debug.Log(n + "th syllable set up");
                    n++;

                }
                wordComposerStarted = true;
            }
        }
	}

    public void checkPlaying()
    {
        Debug.Log("IsPlaying? " + isPlaying); //VS debug
        //consoleLog.text += "isplaying? " + isPlaying + "\n"; //Hololens in game
    }

    public void checkWords()
    {
        Debug.Log("tc =" + tickCount + ", wc=" + currentWord + ", w=" + words.words.Count + "\n"); //VS debug
        //consoleLog.text += "tc =" + tickCount + ", wc=" + currentWord + ", w=" + words.words.Count + "\n"; //Hololens in game
    }
}
