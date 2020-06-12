using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToStart : MonoBehaviour {
	public AudioClip _audioClip_Death;
	public GameObject StartPoint;
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			other.gameObject.transform.position = StartPoint.transform.position;
			other.gameObject.transform.rotation = StartPoint.transform.rotation;
			other.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
			other.gameObject.GetComponent<AudioSource>().PlayOneShot(_audioClip_Death);
		}
		else 
		{
			Destroy(other.gameObject);
		}
	}
}
