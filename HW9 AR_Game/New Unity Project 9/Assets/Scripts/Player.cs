using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	CharacterController playerController;
	public float rotSpeed = 300f;
	Vector3 vectorDir = Vector3.zero;
	public float veclocity = 5.0f;
	public float UpSpeed = 5.0f;
	public Animation anim;
	// Use this for initialization
	void Start () {
		playerController = this.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 forward = Input.GetAxis("Vertical") * 
		this.transform.forward * //這個物件自身的local Z軸向量 轉換成世界座標向量
		veclocity;
		

		this.transform.Rotate(new Vector3(
			0,
			Input.GetAxis("Horizontal")* rotSpeed * Time.deltaTime,
			0));

		playerController.Move(forward*Time.deltaTime); //不受重力影響
		playerController.SimpleMove(Physics.gravity);//受重力影響

		if(Input.GetButton("Jump")){
			if(playerController.isGrounded){ //判斷在地上
				vectorDir.y = UpSpeed;
			}
		}else{
			if(playerController.isGrounded){
				if(Input.GetButton("Horizontal") || Input.GetButton("Vertical")){ //上下左右
					anim.Play("WALK");
				}else{
					anim.Play("IDLE");
				}
			}
			else
			{
				anim.Play("JUMP");
			}
		}
		if(vectorDir.y >= 0f) vectorDir.y -= 3.0f * Time.deltaTime;
		playerController.Move(vectorDir*Time.deltaTime);
	}

	private void OnTriggerEnter(Collider other) {
		switch(other.tag)
		{
			
		}
	}
}
