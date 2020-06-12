using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	[HideInInspector] public bool bTouch = false;
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody>().velocity = new Vector3(-8f,8f,0f);
	}
	
	// Update is called once per frame
	void Update () {
	}

	private void OnBecameInvisible()
	{
		Destroy(this.gameObject);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "Floor")
		{
			Destroy(this.gameObject);
		}
	}
}
