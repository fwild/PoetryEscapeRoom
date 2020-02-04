using UnityEngine;

public class CollisionHandler : MonoBehaviour {

    public int zone;
    private ZoneManager zm;

	// Use this for initialization
	void Start () {
        zm = GameObject.Find("UnbodyManagers").GetComponent<ZoneManager>();
        Debug.Log("CollisionHandler - Got ZoneManager.");
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        zm.ActivateZone(zone);
        Debug.Log("CollisionHandler - Collider in zone " + zone + " has been triggered, setting zone " + zone + " to active zone.");
    }

}
