using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float fSpeed = 0.2f;
	private Vector3 targetPos;
	public Vector3 inBoxPos;
	//public Transform player;
	[HideInInspector]public bool bIsEnterBox;
	[HideInInspector]public int iScore;
	// Use this for initialization
	void Start () {
		iScore = 0;
		bIsEnterBox = false;
		targetPos = this.transform.parent.position;
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		
		//發射線 看到button
		if(Physics.Raycast(transform.position,transform.forward,out hit))//甚麼位置 往哪裡發射 儲存照射的對象(對像必須有collider)
		{
			//Debug.Log(hit.transform.name);
			if(hit.transform.GetComponent<DoorButton>() != null)
			{
				hit.transform.GetComponent<DoorButton>().OnLook();
				MoveToBox();
			}
		}

		//移動自身父物件前進
		this.transform.parent.position = 
			Vector3.Lerp(this.transform.parent.position,targetPos,Time.deltaTime*fSpeed);
		
		//發射線 看到敵人
		if(Input.GetButtonDown("Fire1"))
		{
			RaycastHit enemyHit;
			if(Physics.Raycast(transform.position,transform.forward,out enemyHit))
			{
				if(enemyHit.transform.GetComponent<Enemy>()!=null)
				{
					Destroy(enemyHit.transform.gameObject);
					iScore++;
				}
			}
		}
	}
	private void MoveToBox(){
		targetPos = inBoxPos;
		bIsEnterBox = true;
	}
}
