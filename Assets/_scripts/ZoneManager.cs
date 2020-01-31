using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneManager : MonoBehaviour {

    GameObject Zone1Container;
    GameObject Zone2Container;
    GameObject Zone3Container;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void setActiveWithChildren ( GameObject z, bool active)
    {
        z.SetActive(active);
        for (int a =0; a<z.transform.childCount; a++)
        {
            z.transform.GetChild(a).gameObject.SetActive(active);
        }
    }
    
    public void ActivateZone(int whichZone)
    {
        if (whichZone == 1)
        {
            setActiveWithChildren(Zone1Container, true);
            setActiveWithChildren(Zone2Container, false);
            setActiveWithChildren(Zone3Container, false);

        }
        else if (whichZone == 2)
        {

            setActiveWithChildren(Zone1Container, false);
            setActiveWithChildren(Zone2Container, true);
            setActiveWithChildren(Zone3Container, false);

        }
        else if (whichZone == 3)
        {

            setActiveWithChildren(Zone1Container, false);
            setActiveWithChildren(Zone2Container, false);
            setActiveWithChildren(Zone3Container, true);

        }
    } 


}
