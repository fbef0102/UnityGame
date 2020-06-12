using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bird : MonoBehaviour {
    public AudioSource audioSource;
	public AudioClip audiodeadsound;
	public float speed = 2f;
	public Rigidbody2D Rigidbody2D;
	public float force = 1f;

	// Use this for initialization
	void Start () { 
		Rigidbody2D.velocity = Vector2.right*speed;
	}
	
	// Update is called once per frame
	void Update () {
		if(UIMenu.GameIsStared() && !UIMenu.GameIsPaused())
		{
			if(Input.GetKeyDown(KeyCode.Space)){
				if(Rigidbody2D.velocity.y < 0) Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x,0);
			}
			if(Input.GetKey(KeyCode.Space)){
				Rigidbody2D.AddForce(Vector2.up*force);
			}
			Rigidbody2D.AddForce(Vector2.right*0.04f);
		}
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.layer == 8)
		{
			GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();
			audioSource.PlayOneShot(audiodeadsound);
			GameObject.Find("Canvas_Menu").GetComponent<UIMenu>().SetHightScore();
			StartCoroutine(RestartGame()); //呼叫restartfame 不受到Time.timeScale = 0f 時間暫停影響
			//Invoke("RestartGame",3.5f);
			Time.timeScale = 0f;
		}
	}
	IEnumerator RestartGame()
	{
		 yield return new WaitForSecondsRealtime(3.5f);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		//Application.LoadLevel(Application.loadedLevel); /*另一寫法*/
	}
}
