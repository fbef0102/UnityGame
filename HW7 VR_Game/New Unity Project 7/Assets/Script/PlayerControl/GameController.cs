using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public TextMesh infoTest;
	public Player player_camera;
	public Transform enemyContainer;
	public float fRestartTime = 3.0f;
	private float fTime;
	private void Start() {
		infoTest.text = "找到按鈕\n進入Building內!!";
		fTime = 0f;
	}

	private void Update() {
		if(player_camera.bIsEnterBox == true)
		{
			int enemiesRemaining = enemyContainer.GetComponentsInChildren<Enemy>().Length;
			infoTest.text = "消滅所有黃球! 分數: " + player_camera.iScore;
			infoTest.text += "\n剩餘黃球數量: " + enemiesRemaining;

			if(enemiesRemaining == 0)
			{
				//infoTest.text = "你贏了!! 重來倒數: " + Mathf.CeilToInt(fRestartTime);
				//fRestartTime = fRestartTime - Time.deltaTime;
				//if(fRestartTime<=0)
				//{
				//	SceneManager.LoadScene(SceneManager.GetActiveScene().name);
				//}

				StartCoroutine(Timer_ChangeScene(SceneManager.GetActiveScene().name));
			}
		}	
	}

	
	IEnumerator Timer_ChangeScene(string NextSceneName)
	{
		Time.timeScale = 0f;
		fTime+=Time.fixedDeltaTime;
		infoTest.text = "你贏了!! 重來倒數: " + Mathf.CeilToInt(fRestartTime-fTime);
		yield return new WaitForSecondsRealtime(fRestartTime);
		SceneManager.LoadScene(NextSceneName);
		Time.timeScale = 1;
	}
	
}
