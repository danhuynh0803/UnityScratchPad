using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public EnemyMovement myMovement; 				
	public GameObject gsSteppedOn; 				// Game object of the stepped on sprite

	Vector3 lastPosition; 						// Track final position of slime
	Quaternion lastRotation; 					// Track rotation

	void Update() 
	{
		lastPosition = this.gameObject.transform.position;
		lastRotation = this.gameObject.transform.rotation; 
	}

	void OnTriggerEnter2D(Collider2D other) 
	{	// Instantiate the stepped on sprite when player enters collider
		if (other.tag == "Player") 
		{
			Destroy(this.gameObject); 
			Instantiate(gsSteppedOn, lastPosition, lastRotation);	
		}
	}
}
