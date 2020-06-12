using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public AudioClip _audioClip_Reward;
	public AudioClip _audioClip_Death;
	public AudioSource _audioSource;
	public Text text_Remaining; 
	public GameObject StartPoint;
	public Transform Collected_Pig;
	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "Pig")
		{
			Destroy(other.gameObject);
			_audioSource.PlayOneShot(_audioClip_Reward);
			//GameObject[] leftpigs = GameObject.FindGameObjectsWithTag("Pig");
			//text_Remaining.text = "剩餘數量: " + (leftpigs.Length-1);
			int leftpigs = Collected_Pig.childCount-1;
			text_Remaining.text = "剩餘數量: " + leftpigs;
			
		}
		
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Bird")
		{
			BackToStartPoint(this.gameObject);
			_audioSource.PlayOneShot(_audioClip_Death);
		}
	}
	public void BackToStartPoint(GameObject player)
	{
		player.transform.position = StartPoint.transform.position;
		player.transform.rotation = StartPoint.transform.rotation;
		player.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
	}
}
