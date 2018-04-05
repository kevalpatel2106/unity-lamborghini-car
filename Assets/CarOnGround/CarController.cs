using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {
		
	private bool isSoundPlayed = false;

	// Update is called once per frame
	void Update () {

		if(!isSoundPlayed && transform.localPosition.y < .05f){
			isSoundPlayed = true;
			StartCoroutine (DelaySound ());
		}
	}

	public void MoveCar(){
		transform.localPosition += new Vector3 (0, 10, 0);
		transform.eulerAngles += new Vector3 (5, 20, 5);
		isSoundPlayed = false;
	}

	IEnumerator DelaySound(){
		yield return new WaitForSeconds (.2f);
		GetComponent<AudioSource> ().Play ();
	}
}
