using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDominoes : MonoBehaviour {
	public GameObject dominoesPrefab;
	public GameObject dominoesEnd;
	public int NumCenterDom = 25;

	// Use this for initialization
	void Start () {
		Vector3 dir = dominoesEnd.transform.position - this.transform.position;
		float interval = dir.magnitude / (NumCenterDom+1);
		dir.Normalize();	
		for(int i = 1; i <= NumCenterDom;++i)
		{
			Instantiate(dominoesPrefab,
			this.transform.position + dir * interval * i,
			this.transform.rotation);
		}	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
