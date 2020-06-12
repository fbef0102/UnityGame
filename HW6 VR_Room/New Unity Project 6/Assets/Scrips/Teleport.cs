using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {
	private float timeSpentGazingAt = 0.0f;
	private bool isGazingAtObject = false;
	public float speed = 2.0f;
	private bool isMovingTowardObject = false;
	private Vector3 thisOriginalPos;
	public GameObject player;
	public float ObjDistance = 0.1f; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(isGazingAtObject){
			timeSpentGazingAt += Time.deltaTime;
		}
		
		if(timeSpentGazingAt > 1.5f){
			isGazingAtObject = false;
			isMovingTowardObject = true;
			timeSpentGazingAt =0;
			thisOriginalPos = this.transform.position;
		}	
		if(isMovingTowardObject){
			player.transform.position = Vector3.MoveTowards(
				player.transform.position,
				thisOriginalPos,
				speed*Time.deltaTime);
		}
		if(player.transform.position == transform.position || 
			Vector3.Distance(player.transform.position,transform.position) < ObjDistance )
		{
			isMovingTowardObject = false;
			if(this.GetComponent<GetObject>()==null) GetComponent<SphereCollider>().enabled = false;
		}
		else
		{
			if(this.GetComponent<GetObject>()==null) GetComponent<SphereCollider>().enabled = true;
		}
		
	}
	
	public void OnGazeEnter()
	{
		isGazingAtObject = true;
		timeSpentGazingAt = 0;
	}
	public void OnGazeExit()
	{
		isGazingAtObject = false;
	}
}
