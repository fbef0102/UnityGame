using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour {
	Vector3 offest;
	public GameObject target;

	// Use this for initialization
	void Start () {
		offest = this.transform.position - target.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = target.transform.position+offest;
	}
}
