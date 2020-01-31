using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestZoneManager : MonoBehaviour {
    int tick = 0;
    int zone = 0;
    private ZoneManager zm;
	// Use this for initialization
	void Start () {
        zm = this.GetComponent<ZoneManager>();
	}
	
	// Update is called once per frame
	void Update () {
        tick++;

        if (tick > 200)
        {
            zone++;
            if (zone > 3) zone = 0;
            zm.ActivateZone(zone);
            tick = 0;
        }
	}
}
