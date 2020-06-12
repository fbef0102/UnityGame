using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour {

	public Door door;
	public void OnLook(){
		door.LowerDoor();
	}
}
