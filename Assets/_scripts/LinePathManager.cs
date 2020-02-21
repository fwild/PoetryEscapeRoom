using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinePathManager : MonoBehaviour {

    public List<GameObject> zone3Objects;

    public Color c1 = Color.yellow;
    public Color c2 = Color.red;
    public int lengthOfLineRenderer = 10;

    void Start () {
        //visitingOrder = new int[] { 0, 3, 2, 1, 4, 5, 8, 7, 9, 10};
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void drawLines()
    {

        LineRenderer lr = this.gameObject.AddComponent<LineRenderer>();

        lr.material = new Material(Shader.Find("Sprites/Default"));
        lr.widthMultiplier = 0.2f;
        lr.positionCount = zone3Objects.Count;

        // A simple 2 color gradient with a fixed alpha of 1.0f.
        float alpha = 1.0f;
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(c1, 0.0f), new GradientColorKey(c2, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
        );
        lr.colorGradient = gradient;

        int i = 0;
        foreach (GameObject go in zone3Objects)
        {
            Debug.Log("LINE DRAWING: " + i);
            lr.SetPosition(i, go.transform.position);
            i++;
        }

    }

    public void visitAsset(GameObject go)
    {
        zone3Objects.Add(go);
    }

}
