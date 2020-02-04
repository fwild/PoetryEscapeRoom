using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour {

    private float upForce = -0.5f;
    private float sideForce = 0.1f;

	// Use this for initialization
	void Start () {
        float xForce = Random.Range(-sideForce, sideForce);
        float yForce = Random.Range(upForce / 2f, upForce);
        float zForce = Random.Range(-sideForce, sideForce);

        Vector3 force = new Vector3(xForce, yForce, zForce);

        GetComponent<Rigidbody>().velocity = force;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
