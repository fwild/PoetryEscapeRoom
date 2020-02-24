using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionController : MonoBehaviour {

    public TextMesh theTextMesh;
    public GameObject theLine;
    private LineRenderer lr;
    public Camera arCamera;

    // Use this for initialization
    void Start () {

        showInstruction("UNBODY\n Air-tap or say 'start' to begin...");
        lr = theLine.GetComponent<LineRenderer>();
        DrawViewFinder();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Intro()
    {
        showInstruction("Stand where the body lies...");
    }

    public void showInstruction(string message)
    {
        if (message == "")
        {
            theLine.SetActive(false);
            theTextMesh.text = message;
        }
        else
        {
            theLine.SetActive(true);
            theTextMesh.text = message;
        }
    }

    void DrawViewFinder()
    {

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

        float xfac = 0.8f * 0.125f;
        float yfac = 0.5f * 0.125f;
        float zfac = 0.3f;//0.3f;
        lr.SetPosition(0, arCamera.transform.position + xfac * Vector3.left + yfac * Vector3.up + zfac * Vector3.forward);
        lr.SetPosition(1, arCamera.transform.position + xfac * Vector3.right + yfac * Vector3.up + zfac * Vector3.forward);
        lr.SetPosition(3, arCamera.transform.position + xfac * Vector3.left + yfac * Vector3.down + zfac * Vector3.forward);
        lr.SetPosition(2, arCamera.transform.position + xfac * Vector3.right + yfac * Vector3.down + zfac * Vector3.forward);
        lr.SetPosition(4, arCamera.transform.position + xfac * Vector3.left + yfac * Vector3.up + zfac * Vector3.forward);

    }

}
