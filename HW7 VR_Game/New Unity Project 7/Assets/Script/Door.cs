using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	public float fSpeed = 1.0f;
	private Vector3 targetPos;
	public Vector3 lowerPos;
	void Start() {
		targetPos = this.transform.localPosition; //相對於父物件的 該物件區域座標	
	}
	void Update()
	{
		
		this.transform.localPosition = 
			Vector3.Lerp(this.transform.localPosition,targetPos,Time.deltaTime*fSpeed);
	}
	[ContextMenu("拉下門")]
	public void LowerDoor()
	{
		targetPos = lowerPos;
	}
}
