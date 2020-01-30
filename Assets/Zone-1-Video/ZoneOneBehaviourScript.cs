using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoneOneBehaviourScript : MonoBehaviour {

    public GameObject[] imageTargets;
    public Collider boxCollider;

    public Transform hololens;

    private bool zone1initialise = false;

    public Text printData;

	// Use this for initialization
	void Start () {
		foreach (GameObject image in imageTargets)
        {
            image.SetActive(false);
        }
        printData.text += "Zone1: started the program";
	}
	
	// Update is called once per frame
	void Update () {
        //hasHitCollider();
	}

    void hasHitCollider()
    {
        // if boxCollider.CompareTag
        if (boxCollider.CompareTag(hololens.tag))
            printData.text += "Hololens is colliding with the cube collider to trigger zone 1..\n";
        {
            // hololens has touched zone box collider
            if (!zone1initialise)
            {
                foreach (GameObject image in imageTargets)
                {
                    image.SetActive(true);
                }
                zone1initialise = true;
                printData.text += "Zone 1 has been initialised!\n"; 
                // zone 1 initialised
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach (GameObject image in imageTargets)
        {
            image.SetActive(true);
        }
    }
}
