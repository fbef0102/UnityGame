using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalTrigger : MonoBehaviour {
	public MyCharactor charactor;
	public Text FinishText;
	private void Start() {
		FinishText.enabled = false;
	}

	private void OnTriggerEnter(Collider other) {
		if(other.name == "MyCharactor")
		{
			FinishText.enabled = true;
			FinishText.text = "Finish";
			charactor.CharactorStop();
		}
	}
}
