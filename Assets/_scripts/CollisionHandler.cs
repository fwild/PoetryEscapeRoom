﻿using UnityEngine;

public class CollisionHandler : MonoBehaviour {

    public int zone;
    private ZoneManager zm;
    public InstructionController Instr;

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
        if (zone == 1)
        {
            Instr.showInstruction(""); // empty the message panel
        }
        zm.ActivateZone(zone);
        Debug.Log("CollisionHandler - Collider in zone " + zone + " has been triggered, setting zone " + zone + " to active zone.");
    }

}
