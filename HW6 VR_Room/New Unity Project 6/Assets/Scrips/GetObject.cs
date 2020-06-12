using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetObject : MonoBehaviour {

	public GameObject Obj;
	public AudioClip _audioclip_Reward;

	private void Start() {
		Obj.SetActive(false);
	}
	public void OnGazeClick()
	{
		Obj.SetActive(true);
	}
	public void OnButtonClick()
	{
		AudioSource.PlayClipAtPoint(_audioclip_Reward, this.transform.position);
		Destroy(this.gameObject);
		Obj.SetActive(false);
	}

}
