using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushDominoes : MonoBehaviour {
	public GameObject dominoesStart;
	public float force = 4.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
		{
			dominoesStart.GetComponent<Rigidbody>().AddForce(force,0,0,ForceMode.Impulse);
		}
		
	}
}
