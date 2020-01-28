using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;
using UnityEngine.UI;
using HoloToolkit.Unity.SpatialMapping;
using HoloToolkit.Unity.InputModule;

public class PopulateSpace : Singleton<PopulateSpace> {

    [Tooltip("List of 3D objects to be placed into the room (once room is scanned)")]
    public List<GameObject> ObjectCollection = new List<GameObject>();

    public Text log;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // handler for placing all prefabs from the ObjectCollection
    public void InstallObjects() {

        GameObject.Find("SpatialMappingCtrlMenu").SetActive(false); // hide Space Scan Ctrl Menu
        SpatialMappingManager.Instance.DrawVisualMeshes = false; // hide Spatial Map Mesh

        log.text += "placing objects...\n";

        foreach(GameObject Obj in ObjectCollection)
        {

            log.text += "placing "+Obj.name + "\n";

            GameObject currObj = Instantiate(Obj);
            currObj.transform.localScale *= 0.5f;
            
            currObj.GetComponent<Placeable>().OnSelect();

        }

        log.text = "";


    } // InstallObjects()

}
