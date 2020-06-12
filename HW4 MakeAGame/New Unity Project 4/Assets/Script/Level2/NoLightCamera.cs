using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoLightCamera : MonoBehaviour {
	public Light sun;
	void OnPreCull () {
		if (sun != null)
			sun.enabled = false;
	}

	void OnPreRender() {
		if (sun != null)
			sun.enabled = false;
	}
	void OnPostRender() {
		if (sun != null)
			sun.enabled = true;
	}
}
