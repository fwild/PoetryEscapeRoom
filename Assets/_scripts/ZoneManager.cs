using HoloToolkit.Unity.SpatialMapping;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneManager : MonoBehaviour {

    public GameObject Zone1Container;
    public GameObject Zone2Container;

    public GameObject Zone1Collider;
    public GameObject Zone2Collider;

    public GameObject zone1Poem;


    // Use this for initialization
    void Start () {
        //Zone1Collider.SetActive(true);
        //Zone2Collider.SetActive(true);
        //Zone3Collider.SetActive(true);
        //Zone4Collider.SetActive(true);
        //setActiveWithChildren(Zone1Container, false);
        //setActiveWithChildren(Zone2Container, false);
        //setActiveWithChildren(Zone3Container, false);
        //setActiveWithChildren(Zone4Container, false);
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
        if (SpatialMappingManager.Instance.IsObserverRunning())
            SpatialMappingManager.Instance.StopObserver();
        
        SpatialMappingManager.Instance.StartObserver();
        SpatialMappingManager.Instance.DrawVisualMeshes = false; // turn off visual meshes spatial mapping

        if (whichZone == 1)
        {
            Debug.Log("ZoneManager - Activating zone 1");

            AudioSource am = zone1Poem.GetComponent<AudioSource>();
            am.Play(0);

        }
        else if (whichZone == 2)
        {
            Debug.Log("ZoneManager - Activating zone 2");
            Zone1Collider.SetActive(false);
            Zone2Collider.SetActive(false);
            //Zone3Collider.SetActive(true);
            //Zone4Collider.SetActive(true);

            setActiveWithChildren(Zone1Container, false);
            //setActiveWithChildren(Zone2Container, true);
            //setActiveWithChildren(Zone3Container, false);
            //setActiveWithChildren(Zone4Container, false);


        }

    } 


}
