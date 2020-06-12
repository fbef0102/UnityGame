using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour { 
	public GameObject PauseMenuPanel;
	public GameObject ScoreMenuPanel;
	private static bool gameIsPaused;
	private static bool bGameIsStared;
	public Text Text_Score;
	private int score;
	public Text Text_HighSore;
	private static int PreHightScore = 60;
    void Start () {
		bGameIsStared = false;
		PauseGame ();
		GameMenu();

		score = 0;
		Text_Score.text = "Score: " + score.ToString();
		if(PlayerPrefs.GetInt("HighScore") < 60) PlayerPrefs.SetInt("HighScore",PreHightScore);
		Text_HighSore.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();
    }   

	void Update() {
		if(Input.GetKeyDown(KeyCode.Escape) && bGameIsStared)
		{
			Debug.Log("press esc");
			if(gameIsPaused)
			{
				ResumeGame();
			}
			else
			{
				PauseGame();
				GameMenu();
			}
		}
		
	}

	// pause menu
	public void RestartButtonClick()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	public void StartGameButtonClick()
	{
		bGameIsStared = true;
		ResumeGame();
		GameObject.Find("Main Camera").GetComponent<AudioSource>().Play(0);
		CountScore();
		//GameObject.Find("CreateObstacle").GetComponent<CreateObstacle>().Call_CreateObstacleTimer();
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
		PauseMenuPanel.SetActive(true);
        gameIsPaused = true;
        Time.timeScale = 0f;
	}

	public void ResumeGame()
	{
		PauseMenuPanel.SetActive(false);
		gameIsPaused = false;
      	Time.timeScale = 1;
	}
 
	public void GameMenu()
	{
		if(bGameIsStared)
		{
			PauseMenuPanel.transform.Find("StartButton").gameObject.SetActive(false);
			PauseMenuPanel.transform.Find("ResumeButton").gameObject.SetActive(true);
			PauseMenuPanel.transform.Find("RestartButton").gameObject.SetActive(true);
		}
		else
		{
			PauseMenuPanel.transform.Find("StartButton").gameObject.SetActive(true);
			PauseMenuPanel.transform.Find("ResumeButton").gameObject.SetActive(false);
			PauseMenuPanel.transform.Find("RestartButton").gameObject.SetActive(false);
		}
	}

	//score menu
	public void CountScore()
	{
		InvokeRepeating("Timer_CountScore",1.0f,1.0f);
		
	}
	public void Timer_CountScore()
	{
		Text_Score.text = "Score: " + (++score).ToString();
	}

	public void SetHightScore()
	{
		if(score > PlayerPrefs.GetInt("HighScore",score))
		{
			PlayerPrefs.SetInt("HighScore",score);
			Text_HighSore.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();
			PlayerPrefs.Save();
		}
	}

	public static bool GameIsPaused()
	{
		return gameIsPaused;
	}

	public static bool GameIsStared()
	{
		return bGameIsStared;
	}
}
