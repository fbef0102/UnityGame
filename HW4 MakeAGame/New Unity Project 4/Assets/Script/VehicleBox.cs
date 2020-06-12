using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleBox : MonoBehaviour {

	void OnCollisionEnter(Collision myCol)
	{
		myCol.gameObject.transform.parent = this.gameObject.transform;
	}
	
	void OnCollisionExit(Collision myCol)
	{
		myCol.gameObject.transform.parent = null;
	}
}
