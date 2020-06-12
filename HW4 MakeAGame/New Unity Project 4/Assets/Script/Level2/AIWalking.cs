﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 
public class AIWalking : MonoBehaviour {
	private NavMeshAgent agent;    //宣告NavMeshAgent
	private int destPoint = 0;
	private Transform[] points;
	public Transform AI_Path;
	// Use this for initialization
	void Start () {
		points = new Transform[AI_Path.childCount];
		for(int i=0;i<AI_Path.childCount;++i)
		{
			points[i] = AI_Path.GetChild(i).transform;
		}
		agent = GetComponent<NavMeshAgent> ();  


		// Disabling auto-braking allows for continuous movement
		// between points (ie, the agent doesn't slow down as it
		// approaches a destination point).
		agent.autoBraking = false;
		GotoNextPoint();
	}
	
	void Update () {
		// Choose the next destination point when the agent gets
		// close to the current one.
		if (!agent.pathPending && agent.remainingDistance < 0.5f)
			GotoNextPoint();
	}
	void GotoNextPoint() {
		// Returns if no points have been set up
		if (points.Length == 0)
			return;
	
		// Choose the next point in the array as the destination,
		destPoint = Random.Range(0,points.Length);
		// Set the agent to go to the currently selected destination.
		agent.destination = points[destPoint].position;
	}
	
}
