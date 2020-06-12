using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour {

	public float RotationSpeed = 1.0f;
	public Transform camPivot;
    //public Transform Player;
	float mouseX, mouseY;
	// Use this for initialization
	void Start () {
		//Cursor.visible = false;
		//Cursor.lockState = CursorLockMode.Locked;
	}
	
	private void LateUpdate() {
		CamControl();
	}

	void CamControl()
	{
		mouseX += Input.GetAxis("Mouse X") * RotationSpeed * Time.deltaTime;
		mouseY -= Input.GetAxis("Mouse Y") * RotationSpeed * Time.deltaTime;
		mouseY = Mathf.Clamp(mouseY, -60,60);

		//this.transform.LookAt(camPivot); //被鎖定

		camPivot.rotation = Quaternion.Euler(mouseY,mouseX,0);
		//Player.rotation = Quaternion.Euler(0,mouseX,0);
	}
}
