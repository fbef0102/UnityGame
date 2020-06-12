using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharactarController : MonoBehaviour {

	public Transform camPivot;
	public Animator animator;
	private float xVal = 1.5f;
	private float yVal = 1.5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0); // 取得目前動畫的狀態
		if(state.IsName("Base Layer.Jump"))//如果狀態正在跳躍
		{
			gameObject.GetComponent<Rigidbody>().useGravity = false; //移除重力
		}
		else
		{
			gameObject.GetComponent<Rigidbody>().useGravity = true;
		}

		if(Input.GetButtonDown("Fire2"))//右鍵揮手
		{
			animator.SetBool("WaveBool",!animator.GetBool("WaveBool"));
		}

		if(Input.GetKey(KeyCode.CapsLock)) //奔跑
		{
			animator.SetBool("bRun",true);
			PlayerMovement(true);
		}
		else
		{
			animator.SetBool("bRun",false);
			PlayerMovement(false);
		}

		if(Input.GetButtonDown("Jump")) //空白鍵跳躍
		{
			animator.SetBool("bJump",true);
		}
		else
		{
			animator.SetBool("bJump",false);
		}
	}
	void PlayerMovement(bool bRun)
	{
		float AngleDegree = Vector3.Angle(new Vector3(this.transform.forward.x,0,this.transform.forward.z),new Vector3(camPivot.forward.x,0,camPivot.forward.z)); 
		Debug.Log("夾角" + AngleDegree);
		float fAngle = AngleDegree * Mathf.Deg2Rad/2;//角度變成弧度
		//Debug.Log("攝影機角度: " + camPivot.localEulerAngles.y);
		fAngle = (camPivot.localEulerAngles.y > 180) ? -fAngle : fAngle;//給予方向

		float fHorizontal = Input.GetAxis("Horizontal");
		float fVertical = Input.GetAxis("Vertical"); 

		if(!bRun)
		{
			animator.SetFloat("Direction",fVertical * Mathf.Tan(fAngle) + fHorizontal);
			animator.SetFloat("Speed", fVertical * yVal);
		}
		else
		{

			//float fVertical = Input.GetAxis("Vertical"); //往前是1 往後是-1
			animator.SetFloat("Speed", fVertical * yVal); //Speed是animator的參數名稱

			//float fHorizontal = Input.GetAxis("Horizontal"); //往右是1 往左是-1
			animator.SetFloat("Direction", (fVertical * Mathf.Tan(fAngle) + fHorizontal) * xVal); //Direction是animator的參數名稱
		}
	}
}
