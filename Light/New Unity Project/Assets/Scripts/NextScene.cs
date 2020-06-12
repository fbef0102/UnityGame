using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour {
	public string sSceneName;
	public void OnButtonClick()
	{
		SceneManager.LoadScene(sSceneName);
	}
}
