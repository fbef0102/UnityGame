using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public GameObject GroundPoundPS;
	public GameObject explosionPS;
	public GameObject explosionDustPS;
	public GameObject RockChuck;
	public GameObject explosion360;

	private void Update() {
		if(Input.GetKeyDown(KeyCode.Space))
		{
			Instantiate(explosionPS,this.transform.position,explosionPS.transform.rotation);
			Instantiate(explosionDustPS,this.transform.position,explosionDustPS.transform.rotation);
			Instantiate(RockChuck,new Vector3(this.transform.position.x,this.transform.position.y+2.0f,this.transform.position.z),explosionDustPS.transform.rotation);
			this.GetComponent<Rigidbody>().velocity = this.transform.up * 10.0f;
		}
	}

	private void OnCollisionEnter(Collision other) {
		Instantiate(GroundPoundPS,this.transform.position,GroundPoundPS.transform.rotation);
		Instantiate(explosion360,this.transform.position,GroundPoundPS.transform.rotation);
	}
}
