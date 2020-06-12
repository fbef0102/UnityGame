using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class FootSteps : MonoBehaviour {

	RigidbodyFirstPersonController cc;
	AudioSource aa;
	public AudioClip step1;
	public AudioClip step2;
	public AudioClip step3;
	public AudioClip step4;
	public AudioClip Landing;
	float vv;

	// Use this for initialization
	void Start () {
		cc = this.GetComponent<RigidbodyFirstPersonController>();
		aa = this.GetComponent<AudioSource>();
		vv = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(cc.Grounded && cc.Velocity.magnitude > 2f && vv >= 0.4f)
		{
			int number = Random.Range(1,5);
			switch(number)
			{
				case 1: aa.PlayOneShot(step1);break;
				case 2: aa.PlayOneShot(step2);break;
				case 3: aa.PlayOneShot(step3);break;
				case 4: aa.PlayOneShot(step4);break;
			}
			vv = 0f;
		}
		vv += Time.deltaTime;
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.relativeVelocity.y > 3.0f) //反向作用力的向上力道
        {
           aa.PlayOneShot(Landing);
        }
    }
}
