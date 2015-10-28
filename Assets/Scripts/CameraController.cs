using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public PlayerMovement thePlayer; 

	private Vector3 lastPlayerPosition; 
	private float distanceToMove; 

	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerMovement> (); 
		lastPlayerPosition = thePlayer.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{ 
		distanceToMove = thePlayer.transform.position.x - lastPlayerPosition.x; 

		// Move camera by distance that player moves 
		transform.position = new Vector3(transform.position.x + distanceToMove,
		                                 transform.position.y, // maintain no movement in y, z axes
		                                 transform.position.z); 

		lastPlayerPosition = thePlayer.transform.position; 
	}
}
