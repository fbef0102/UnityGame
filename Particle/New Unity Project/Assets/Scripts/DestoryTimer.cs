using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryTimer : MonoBehaviour {

	public float fTimer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		fTimer -= Time.deltaTime;
		if(fTimer < 0)
		{
			Destroy(this.gameObject);
		}
	}
}
