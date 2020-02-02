using UnityEngine;

public class CollisionHandler : MonoBehaviour {

    public int zone;
    private ZoneManager zm;

	// Use this for initialization
	void Start () {
        zm = GameObject.Find("UnbodyManagers").GetComponent<ZoneManager>();
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collider Trigger Entered !!! ");
        zm.ActivateZone(zone);
    }

}
