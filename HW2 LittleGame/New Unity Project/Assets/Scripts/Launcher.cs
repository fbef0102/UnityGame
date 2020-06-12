using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour {

	public GameObject BallPrefab;
	public GameObject Player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//if(Input.GetButtonDown("Jump"))
		//{
		//	Instantiate(BallPrefab,this.transform.position,this.transform.rotation);
		//}
		if (Input.GetMouseButtonDown(0))
		{
			Instantiate(BallPrefab,this.transform.position,this.transform.rotation);
		}
	}
}
