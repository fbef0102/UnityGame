using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleRunJump : MonoBehaviour {

	public Animator animator;

	void Update()
	{
		//AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0); // 取得目前動畫的狀態
		//if(state.IsName("Base Layer.Run")){ //如果狀態正在跑步
		if(Input.GetButton("Jump"))
		{
			animator.SetBool("bJump",true);
		}
		//}
		else
		{
			animator.SetBool("bJump",false);
		}
		if(Input.GetButtonDown("Fire2"))
		{
			animator.SetBool("WaveBool",!animator.GetBool("WaveBool"));
		}

		float fVertical = Input.GetAxis("Vertical"); //往前是1 往後是-1
		animator.SetFloat("Speed", fVertical); //Speed是animator的參數名稱

		float fHorizontal = Input.GetAxis("Horizontal"); //往右是1 往左是-1
		animator.SetFloat("Direction", fHorizontal); //Direction是animator的參數名稱
	}
}
