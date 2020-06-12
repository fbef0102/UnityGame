using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour {

	public GameObject BirdPrefab;	
	public float fSpeed = 40f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!GameObject.Find("Canvas").GetComponent<UIMenu>().IsPauseing() && Input.GetButtonDown("Fire1")){
			GameObject obj  = Instantiate(BirdPrefab,this.transform.position,this.transform.rotation);
			obj.GetComponent<Rigidbody>().position = this.transform.position;
			obj.GetComponent<Rigidbody>().velocity = this.transform.forward  * fSpeed;//物體前方的向量

			Destroy(obj,5f);//幾秒後生效摧毀
		}
	}
}
