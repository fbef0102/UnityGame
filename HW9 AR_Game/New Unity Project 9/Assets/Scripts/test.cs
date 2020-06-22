using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//this.transform.Translate( Vector3.right,Space.World);

		this.transform.Translate( this.transform.right);
	}
}
