using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour {
	public GameObject Panel_PauseMenu;
	public GameObject Panel_MainMenu;
	public GameObject Panel_PlayerMenu;
	public PlayableDirector director;
	public PlayableDirector director2;
	public GameObject player;
	public GameObject StartPoint;
	private static bool bGameIsPaused;
	private static bool bGameIsStared;
	public static bool bCanPause;
	private static bool bLevel1;
    void Start () {
		if(SceneManager.GetActiveScene().name == "Level1")
		{
			bLevel1 = true;
		}
		else 
			bLevel1 = false;

		if(bLevel1) 
		{
			director.Play();
			player.SetActive(false);
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			bGameIsStared = false;
			bGameIsPaused = false;
		}
		else
			bGameIsStared = true;

		bGameIsPaused = false;
		bCanPause = true;
		GameMenu();
    }  

	void Update() {
		if(bCanPause && Input.GetKeyDown(KeyCode.Escape) && bGameIsStared)
		{
			if(bGameIsPaused)
			{
				ResumeGame();
			}
			else
			{
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
				PauseGame();
			}
		}
		
	}
 	public void PlayLevel1ButtonClick()
	{
		bGameIsStared = true;
		GameObject.Find("BackGround_Music").GetComponent<AudioSource>().Play();
		if(bLevel1) 
		{
			director2.Stop();
			player.SetActive(true);
			GameObject.Find("IntroCamera_Center").SetActive(false);
		}
		ResumeGame();
	}
 	public void PlayLevel2ButtonClick()
	{
		SceneManager.LoadScene("level2");
	}
	// pause menu
	public void MainButtonClick()
	{
		SceneManager.LoadScene("Level1");
		ResumeGame();
	}
	public void RestartButton()
	{
		player.transform.position = StartPoint.transform.position;
		player.gameObject.transform.rotation = StartPoint.transform.rotation;
		player.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
		ResumeGame();
	}
	public void ResumeButtonClick()
	{
		ResumeGame();
	}
	public void QuitGameButtonClick()
	{
		Application.Quit();
	}
	public void PauseGame ()
    {
        bGameIsPaused = true;
        Time.timeScale = 0f;
		GameMenu();
	}

	public void ResumeGame()
	{
		bGameIsPaused = false;
      	Time.timeScale = 1;
		GameMenu();
	}
	public void GameMenu()
	{
		if(bGameIsStared)
		{
			if(bGameIsPaused) Panel_PauseMenu.SetActive(true);
			else Panel_PauseMenu.SetActive(false);
			if(bLevel1) Panel_MainMenu.SetActive(false);
			Panel_PlayerMenu.SetActive(true);
		}
		else
		{
			if(bLevel1) Panel_MainMenu.SetActive(true);
			Panel_PauseMenu.SetActive(false);
			Panel_PlayerMenu.SetActive(false);
		}
	}
	public bool IsPauseing()
	{
		return bGameIsPaused;
	}

}
