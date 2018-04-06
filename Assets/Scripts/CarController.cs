using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

	void OnTriggerEnter(Collider collider){
		if(collider.CompareTag("ImageTarget")){
			GetComponent<AudioSource> ().Play ();
		}
	}

	void OnTriggerExit(Collider collider){
		if(collider.CompareTag("ImageTarget")){
			GetComponent<AudioSource> ().Stop ();
		}
	}
}
