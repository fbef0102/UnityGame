using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMaze : MonoBehaviour {

	public float speed = 50f;
	public float MaxAngle = 30.0f;
	float XCurRotation = 0f;
	float ZCurRotation = 0f;
	public Rigidbody Ball;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Ball.WakeUp();
		
		float XRot = 0f;
		float ZRot = 0f;

		if(Input.GetKey(KeyCode.UpArrow))
		{
			XRot = Time.deltaTime * speed;
		}	

		if(Input.GetKey(KeyCode.DownArrow))
		{
			XRot = Time.deltaTime * -speed;
		}

		if(Input.GetKey(KeyCode.RightArrow))
		{
			ZRot = Time.deltaTime * -speed;
		}	

		if(Input.GetKey(KeyCode.LeftArrow))
		{
			ZRot = Time.deltaTime * speed;
		}

		
		if( (XCurRotation + XRot  < -MaxAngle ) || (XCurRotation + XRot > MaxAngle) ||
			(ZCurRotation + ZRot  < -MaxAngle ) || (ZCurRotation + ZRot > MaxAngle) )
		{
			return;
		}

		XCurRotation +=	XRot;
		ZCurRotation += ZRot;

		this.transform.Rotate(Vector3.right * XRot);
		this.transform.Rotate(Vector3.forward * ZRot,Space.World);
	}
}
