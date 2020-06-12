using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour {

	public AudioClip _audioClip_LevelComplete;
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			if(SceneManager.GetActiveScene().name == "Level1")
			{
				StartCoroutine(Timer_ChangeScene("level2"));
			}
			else if (SceneManager.GetActiveScene().name == "Level2")
			{
				if(GameObject.FindWithTag("Pig") == null)
					StartCoroutine(Timer_ChangeScene("level1"));
			}
		}
	}
	IEnumerator Timer_ChangeScene(string NextSceneName)
	{
		Time.timeScale = 0f;
		GameObject.Find("BackGround_Music").GetComponent<AudioSource>().Stop();
		AudioSource.PlayClipAtPoint(_audioClip_LevelComplete, this.transform.position);
		UIMenu.bCanPause = false;
		yield return new WaitForSecondsRealtime(7.0f);
		SceneManager.LoadScene(NextSceneName);
		UIMenu.bCanPause = true;
		Time.timeScale = 1;
	}
}
