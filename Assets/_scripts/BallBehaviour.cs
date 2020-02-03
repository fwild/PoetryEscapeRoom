using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour {

    private Vector3 pos;
    private float speed = 25f;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        //rotate balls in the air 
        //this.transform.RotateAround(pos, new Vector3(0f, 0f, 0f), 90f * Time.deltaTime);
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
        //transform.Rotate(GetComponentInParent<GameObject>().transform.position, 20 * Time.deltaTime, 0);
    }
}
