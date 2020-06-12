using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour {

	public TextMesh infoTest;
	public Transform MagicLamp_Collected;
	private float fTime;
	public float fRestartTime = 5.0f;
	// Use this for initialization
	void Start () {
		fTime = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		int TargetRemaining = MagicLamp_Collected.GetComponentsInChildren<GetObject>().Length;
		infoTest.text = "收集神燈! 剩餘數量: " + TargetRemaining;

		if(TargetRemaining == 0)
		{

			StartCoroutine(Timer_ChangeScene(SceneManager.GetActiveScene().name));
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
