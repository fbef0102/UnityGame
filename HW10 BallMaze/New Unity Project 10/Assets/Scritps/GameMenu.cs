using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour {
	public GUISkin skin;
	public Image blackMask;
	public BallMaze ballMaze;

	public Text timeText;
	private bool timebool;
	public float time;

	// Use this for initialization
	void Start () {
		ballMaze.enabled = false;
		blackMask.enabled = true;
		timeText.text = "";
		timebool = false;
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;	
	}
	
	// Update is called once per frame
	void Update () {
		if(timebool == true)
		{
			time -= Time.deltaTime;
			timeText.text = Mathf.CeilToInt(time).ToString();
			if(time <= 0)
			{
				ballMaze.enabled = true;
				blackMask.enabled = false;
				this.enabled = false;
				timeText.enabled = false;
				timebool  = false;
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;	
			}
		}
	}

	private void OnGUI() {
		if(!timebool)
		{
			if(GUI.Button(new Rect(100,100,200,100),"Start",skin.button))
			{
				timebool = true;
			}
		}
	}
}
