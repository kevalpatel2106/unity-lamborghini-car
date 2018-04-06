using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMovementController : MonoBehaviour {

	public bool isLeftDoor = false;

	public AudioSource openAudioSource;
	public AudioSource closeAudioSource;

	private bool isDoorOpen = false;

	private float currentAngle = 0f;
	private float desiredAngle = 0f;

	// Update is called once per frame
	void Update () {
		currentAngle = Mathf.LerpAngle (currentAngle, desiredAngle, Time.deltaTime * 3f);
		transform.localEulerAngles = new Vector3 (0, currentAngle, 0);
	}

	void OpenDoors(){
		if (isDoorOpen)
			return;

		if (isLeftDoor) {
			desiredAngle = 60f;
		} else {
			desiredAngle = -60f;
		}
			
		StartCoroutine (DelayCarOpenSound ());
	}

	void CloseDoors(){
		if (!isDoorOpen)
			return;

		desiredAngle = 0f;
		StartCoroutine (DelayCarCloseSound ());
	}

	IEnumerator DelayCarCloseSound(){
		openAudioSource.Stop ();

		yield return new WaitForSeconds (0.4f);

		closeAudioSource.Play ();
		isDoorOpen = false;
	}

	IEnumerator DelayCarOpenSound(){
		closeAudioSource.Stop ();
		openAudioSource.Play ();

		yield return new WaitForSeconds (0.3f);

		isDoorOpen = true;
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
