using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour {

	public Text FinishText;
	private void Start() {
		FinishText.enabled = false;
	}
	private void OnTriggerEnter(Collider other) {
		if(other.CompareTag("Ball"))
		{
			LoadNextScene(SceneManager.GetActiveScene().name,0.1f);
		}
	}
	
	public void LoadNextScene(string SceneName,float fRestartTime)
	{
		StartCoroutine(_Timer_ChangeScene(SceneName,fRestartTime));
	}
	IEnumerator _Timer_ChangeScene(string SceneName,float fRestartTime)
	{
		Time.timeScale = 0f;
		FinishText.enabled = true;
		FinishText.text = "GameOver";
		yield return new WaitForSecondsRealtime(fRestartTime);
		Time.timeScale = 1f;
		SceneManager.LoadScene(SceneName);
	}
}
