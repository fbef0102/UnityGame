using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;    //使用UnityEngine.AI

public class AIWalking2 : MonoBehaviour {

	public GameObject target_obj;    //目標物件
	private NavMeshAgent agent;    //宣告NavMeshAgent
	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();        //接收NavMeshAgent
	}
	
	// Update is called once per frame
	void Update () {
		agent.SetDestination (target_obj.transform.position);
	}
}
