using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCollisionEvent : MonoBehaviour {
	public MyCharactor character;
	bool bSwitchEnable = true;

	private void OnCollisionEnter(Collision other) {
		if(bSwitchEnable == true)
		{
			character.CharactorWalk();
			bSwitchEnable = false;
		}
	}
}
