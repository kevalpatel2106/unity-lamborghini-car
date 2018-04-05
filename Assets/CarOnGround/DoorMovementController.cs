using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMovementController : MonoBehaviour {

	public bool isLeftDoor = false;

	public AudioSource openAudioSource;
	public AudioSource closeAudioSource;

	private float currentAngle = 0f;
	private float desiredAngle = 0f;

	// Update is called once per frame
	void Update () {
		currentAngle = Mathf.LerpAngle (currentAngle, desiredAngle, Time.deltaTime * 3f);
		transform.localEulerAngles = new Vector3 (0, currentAngle, 0);
	}

	void OpenDoors(){
		if (isLeftDoor) {
			desiredAngle = 60f;
		} else {
			desiredAngle = -60f;
		}

		openAudioSource.Play ();
	}

	void CloseDoors(){
		desiredAngle = 0f;
		StartCoroutine (DelayCarCloseSound ());
	}

	IEnumerator DelayCarCloseSound(){
		yield return new WaitForSeconds (0.3f);
		closeAudioSource.Play ();
	}

	void OnTriggerEnter(Collider collider){
		if(collider.CompareTag("MainCamera")){
			OpenDoors ();
		}
	}
		
	void OnTriggerExit(Collider collider){
		if(collider.CompareTag("MainCamera")){
			CloseDoors ();
		}
	}
}
