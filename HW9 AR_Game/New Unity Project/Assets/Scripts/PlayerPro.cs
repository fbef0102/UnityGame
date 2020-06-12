using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerPro : MonoBehaviour {
	CharacterController playerController;
	Transform transformCam;
	Vector3 normalZeroPosition = Vector3.zero;
	Vector3 vectorDir = Vector3.zero;
	public float veclocity = 5.0f;
	public float UpSpeed = 5.0f;

	public Animation anim;
	public GameObject particleEgg;
	public GameObject particleFeather;
	public GameObject particleStar;
	public GameObject Fire;
	public GameObject player;
	public GameObject Collected_Egg;
	public GameObject Collected_Feather;
	float count = 0;
	bool IsStar = false;

	public AudioClip soundEgg;
	public AudioClip soundFeather;
	public AudioClip soundHit;
	public AudioClip soundWin;
	public AudioClip soundStar;
	public AudioClip soundLose;
	public AudioClip soundPickStar;
	public AudioClip soundFry;

	AudioSource audioSource;
	// Use this for initialization
	void Start () {
		playerController = this.GetComponent<CharacterController>();
		transformCam = Camera.main.transform;
		audioSource = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 moveCamFront = Vector3.Scale(transformCam.forward,new Vector3(1,0,1)).normalized ; //向量相乘
		Vector3 moveCamRight = Vector3.Scale(transformCam.right,new Vector3(1,0,1)).normalized ; //向量相乘
		Vector3 move = CrossPlatformInputManager.GetAxis("Vertical") * moveCamFront +
				CrossPlatformInputManager.GetAxis("Horizontal") * moveCamRight;

		//Debug.Log("x: "+ move.x + ", y: "+ move.y + ", z: " + move.z);
		playerController.Move(move*veclocity* Time.deltaTime);
		playerController.SimpleMove(Physics.gravity);//受重力
		
		move.Normalize();
		
		move = this.transform.InverseTransformDirection(move);//從世界座標向量變成這個物件的自身座標向量
		move = Vector3.ProjectOnPlane(move,normalZeroPosition); //(Vector3 投影向量,Vector3 投影平面法向量);
		//Debug.Log("投影之後x: "+ move.x + ", y: "+ move.y + ", z: " + move.z);
		float rotAngle = Mathf.Atan2(move.x,move.z);
		//Debug.Log("角度: " + rotAngle);

		ActoerRotation(move.z,rotAngle);

		if(CrossPlatformInputManager.GetButton("Jump")){
			if(playerController.isGrounded){ //判斷在地上
				anim.Play("JUMP");
				vectorDir.y = UpSpeed;
				audioSource.PlayOneShot(soundFry,0.7f); //音量調整
			}
		}else{
			if(playerController.isGrounded){
				vectorDir.y = 0f;
				if(CrossPlatformInputManager.GetAxis("Horizontal") != 0f || CrossPlatformInputManager.GetAxis("Vertical") != 0f){ //上下左右
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
		playerController.Move(vectorDir * Time.deltaTime);
		//if(vectorDir.y >= 0f) vectorDir.y -= 3.0f * Time.deltaTime;
		
	}

	void ActoerRotation(float rotTime,float rotAngle)
	{
		float turnSpeed = Mathf.Lerp(180,360,rotTime);//180到360 插值法 基于浮点数t返回a到b之间的插值，t限制在0～1之间。当t = 0返回from，当t = 1 返回to。当t = 0.5 返回from和to的平均值。
		//turnSpeed = 300.0f;
		this.transform.Rotate(0,rotAngle * turnSpeed * Time.deltaTime, 0);
	}

	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Egg")
		{
			audioSource.PlayOneShot(soundEgg,0.7f);
			Instantiate(particleEgg,other.gameObject.transform.position,Quaternion.identity); // Quaternion.identity( READ ONLY) : 毫無旋轉，回歸原始旋轉值，簡單來說就 rotation(0,0,0)
			Destroy(other.gameObject);
			Invoke("CheckPickUpObjects",0.1f);
		}
		else if(other.gameObject.tag == "Feather")
		{
			audioSource.PlayOneShot(soundFeather,0.7f);
			Instantiate(particleFeather,other.gameObject.transform.position,Quaternion.identity);
			Destroy(other.gameObject);
			Invoke("CheckPickUpObjects",0.1f);
		}
		else if(other.gameObject.tag == "Star")
		{
			if(IsStar)
			{
				Instantiate(particleStar,other.gameObject.transform.position,Quaternion.identity);
				Destroy(other.gameObject);
				LoadNextScene(SceneManager.GetActiveScene().name,3.0f);
				audioSource.PlayOneShot(soundStar,0.7f);
				audioSource.PlayOneShot(soundWin,0.7f);
			}
		}
		else if(other.gameObject.tag == "Fire")
		{
			audioSource.PlayOneShot(soundHit,0.7f);
			CancelInvoke("HurtFire");
			count = 0;
			InvokeRepeating("HurtFire",0,0.1f);
			playerController.Move(transform.TransformDirection(Vector3.back)*3.0f);
		}
		else if(other.gameObject.tag == "Dead")
		{
			audioSource.PlayOneShot(soundLose);
			LoadNextScene(SceneManager.GetActiveScene().name,2.0f);
		}
	}

	void HurtFire()
	{
		count++;
		player.SetActive(!player.activeInHierarchy);
		if(count > 7)
		{
			count = 0;
			player.SetActive(true);
			CancelInvoke("HurtFire");
		}
	}

	void CheckPickUpObjects()
	{
		//Debug.Log(Collected_Egg.transform.childCount + " ,,"  + Collected_Feather.transform.childCount);
		if(Collected_Egg.transform.childCount == 0 && Collected_Feather.transform.childCount == 0)
		{
			audioSource.PlayOneShot(soundPickStar,0.5f);
			IsStar = true;
			Destroy(Fire);
		}
	}
	public void LoadNextScene(string SceneName,float fRestartTime)
	{
		StartCoroutine(_Timer_ChangeScene(SceneName,fRestartTime));
	}
	IEnumerator _Timer_ChangeScene(string SceneName,float fRestartTime)
	{
		Time.timeScale = 0f;
		yield return new WaitForSecondsRealtime(fRestartTime);
		Time.timeScale = 1f;
		SceneManager.LoadScene(SceneName);
	}
}
