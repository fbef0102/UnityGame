using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour {

	public Text ScoreText;
	public float fJumpSpeed = 10.0f;
	public bool bIsLanding = true;
	private int score = 0;

	// Use this for initialization
	void Start () {
		//Debug.Log("Start");
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log("Update");

		if(bIsLanding && Input.GetButtonDown("Jump"))
		{
			bIsLanding = false;
			this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.up * fJumpSpeed;
		}
		//else if (Input.GetMouseButtonDown(1))	
		//{
		//	GetComponent<Rigidbody>().velocity = new Vector3(0,-1f,0) * fJumpSpeed;
		//}

	}


	private void OnBecameInvisible()
	{
		Destroy(this.gameObject);
	}

	private void OnCollisionEnter(Collision collision)
	{
		/*if(collision.gameObject.name == "Floor")
		{
			Debug.Log("OnCllisionEnter");
			bIsLanding = true;
		}*/
		if(collision.gameObject.tag == "Floor")
		{
			bIsLanding = true;
		}
		else if(collision.gameObject.tag == "Ball")
		{
			if(collision.gameObject.GetComponent<Ball>().bTouch == false)
			{
				collision.gameObject.GetComponent<Ball>().bTouch = true;
				ScoreText.text = "Score: " + (++score).ToString();
			}
		}
	}
}
