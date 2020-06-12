using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCharactor : MonoBehaviour {

	public bool bMoveable = false;
	public GameObject Charctor;
	CharacterController controller;

	public float pushpower = 1.0f;
	// Use this for initialization
	void Start () {
		controller = this.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 speed = new Vector3(0,0,0);
		if(bMoveable)
			speed.x = -3.0f;
		controller.SimpleMove(speed);
	}

	public void CharactorWalk()
	{
		bMoveable = true;
		Charctor.GetComponent<Animation>().Play("walk");
	}

	public void CharactorStop()
	{
		bMoveable = false;
		Charctor.GetComponent<Animation>().Play("idle");
	}

	//CharacterController移動中撞到東西
	private void OnControllerColliderHit(ControllerColliderHit hit) {
		Rigidbody rig = hit.collider.attachedRigidbody;
		if(rig == null || rig.isKinematic)
			return;
		
		Vector3 vecPushDir = new Vector3(hit.moveDirection.x,0,0);

		rig.velocity = vecPushDir * pushpower;
	}
}
