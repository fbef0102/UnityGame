using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : MonoBehaviour {

	public Animator DoorBox;
	public AudioClip _audioClip_OpenDoor;
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player" && DoorBox.GetBool("bOpen") == false)
		{
			DoorBox.SetBool("bOpen",true);
			AudioSource.PlayClipAtPoint(_audioClip_OpenDoor, DoorBox.transform.position);
		}
	}
}
