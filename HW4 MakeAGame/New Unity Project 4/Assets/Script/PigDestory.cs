using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigDestory : MonoBehaviour {

	public GameObject explosion;
	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "Bird")
		{
			GameObject ex = Instantiate(explosion,this.transform.position,this.transform.rotation);
			Destroy(this.gameObject);
			Destroy(ex,5);
			if(other.gameObject.name != "BigBird") Destroy(other.gameObject);
		}
	}

}
