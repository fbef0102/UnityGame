using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TriggerComplete : MonoBehaviour {
	public Image blackMask;
	public BallMaze ballMaze;
	public LoadScene loadScene;
	public AudioSource audioSource;
	public AudioClip audioClip_complete;
	private void Start() {
	}
	private void OnTriggerEnter(Collider other) {
		if(other.CompareTag("Ball"))
		{
			//Debug.Log("Game Over!");
			blackMask.enabled = true;
			ballMaze.enabled = false;
			audioSource.PlayOneShot(audioClip_complete);
			loadScene.LoadNextScene("BallMaze",7.0f);
		}
	}
}
