using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObstacle : MonoBehaviour {
	public GameObject BirdPlayer;
	public GameObject obstacle_two;
	public GameObject obstacle_one_down;
	public GameObject obstacle_one_up;
	public GameObject obstacle_one_middle;
	public GameObject obstacle_one_middle_2;
	public GameObject obstacle_two_big;
	private static readonly int Obstacle_Max = 6;
	public int Obstacle_Next_Distance_Max = 10;
	public int Obstacle_Next_Distance_Min = 20;
	public float Obstacle_Rotation_Angle = 30.0f;
	public float Obstacle_Speed_Max = 5.0f;
	public float Obstacle_Speed_Min = 0f;
	public float Obstacle_SwitchTime_Max = 4f;
	public float Obstacle_SwitchTime_Min = 1f;
	private float TraveledDistance;
	private int Obstacle_Next_Distance;
	// Use this for initialization
	void Start () {
		TraveledDistance = 0;
		Obstacle_Next_Distance = Random.Range(Obstacle_Next_Distance_Min,Obstacle_Next_Distance_Max);
	}
	
	// Update is called once per frame
	void Update () {
		TraveledDistance += BirdPlayer.GetComponent<Rigidbody2D>().velocity.x * Time.deltaTime;
		if(Mathf.FloorToInt(TraveledDistance) / Obstacle_Next_Distance >= 1)
		{
			Timer_CreateObstacle();
			TraveledDistance = 0;
			Obstacle_Next_Distance = Random.Range(Obstacle_Next_Distance_Min,Obstacle_Next_Distance_Max);
		}
	}
	public void Call_CreateObstacleTimer()
	{
		Invoke("Timer_CreateObstacle",5.0f);
	}


	public void Timer_CreateObstacle()
	{
		int iRandomObstacle = Random.Range(1,Obstacle_Max+1); //哪一種障礙物
		float fRandomAngle = Random.Range(-Obstacle_Rotation_Angle,Obstacle_Rotation_Angle); //角度
		float iRandomSpeed  = Random.Range(Obstacle_Speed_Min,Obstacle_Speed_Max);//速度
		float fRandomSwitchTime  = Random.Range(Obstacle_SwitchTime_Max,Obstacle_SwitchTime_Min);//交換時間

		GameObject RandomObstacle = null;
		switch(iRandomObstacle)
		{
			case 1: RandomObstacle = obstacle_two; break;
			case 2: RandomObstacle = obstacle_one_down; break;
			case 3: RandomObstacle = obstacle_one_up; break;
			case 4: RandomObstacle = obstacle_one_middle; break;
			case 5: RandomObstacle = obstacle_one_middle_2; break;
			case 6: RandomObstacle = obstacle_two_big; break;
		}

		GameObject a = Instantiate(RandomObstacle,new Vector3(this.transform.position.x,RandomObstacle.transform.position.y,RandomObstacle.transform.position.z),Quaternion.Euler(0,0,RandomObstacle.transform.rotation.eulerAngles.z+fRandomAngle)); //Y Z 固定, 旋轉Z軸
		a.GetComponent<obstacle>().speed = iRandomSpeed;
		a.GetComponent<obstacle>().switchTime = fRandomSwitchTime;

		//if(iRandomObstacle == 4) fRandomTime += 3.0f;
		//Invoke("Timer_CreateObstacle",fRandomTime);
	}
}
