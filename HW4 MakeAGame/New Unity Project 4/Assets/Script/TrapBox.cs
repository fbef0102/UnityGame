using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBox : MonoBehaviour {

	public AudioClip _audioClip_BoxBreak;
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Bird")
		{
			AudioSource.PlayClipAtPoint(_audioClip_BoxBreak, transform.position);
			Destroy(this.gameObject);
		}
	}
}
