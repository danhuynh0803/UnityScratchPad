using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public Transform target; 
	public float smoothing = 5f; 

	Vector3 cameraOffset; 
	// Use this for initialization
	void Start () { 
		cameraOffset = transform.position - target.position; 
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 targetCamPos = target.position + cameraOffset; 

		// smoothly interpolate the camera
		transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);  
	}
}
