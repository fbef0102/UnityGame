using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour {

	public float speed = 3f;
	public float switchTime = 2.5f;

	public Rigidbody2D rigidbody2D_;
	// Use this for initialization
	void Start () {
		rigidbody2D_.velocity = Vector2.up * speed;
		InvokeRepeating("Switch",0,switchTime);
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	[ContextMenu("Test")] /*測試Debug*/
	private void Switch()
	{
		rigidbody2D_.velocity *= -1;
	}

	private void OnBecameInvisible()
	{
		Invoke("Timer_DestoryObstacle",3.0f);
	}
	private void Timer_DestoryObstacle()
	{
		Destroy(this.gameObject);
	}
}
