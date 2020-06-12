using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendTree2D : MonoBehaviour {

	public Animator animator;
	private float xVal = 1.5f;
	private float yVal = 1.5f;
	void Update() {
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		animator.SetFloat("ValX",h*xVal);
		animator.SetFloat("ValY",v*yVal);

		if(Input.GetButton("Jump"))
		{
			animator.SetBool("bRun",true);
		}
		else
		{
			animator.SetBool("bRun",false);
		}
	}
}
