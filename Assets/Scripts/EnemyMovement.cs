using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public float speed = 5.0f;  				// Control enemy movement speed
	public GameObject player; 					// Finds player in space 
	private Animator myAnimator;  				// Control animations 
	private bool facingPlayer = true; 			// Check if facing player
	private Rigidbody2D myRigidBody; 


	float h; 									// Horizontal movement direction
	Vector3 playerPos; 							// Player position
	Vector3 enemyPos; 							// Enemy position 
	Vector3 distance;							// Distance from player and enemy 
	// Use this for initialization
	
	void Start() 
	{
		player = GameObject.FindWithTag ("Player"); 
		myRigidBody = GetComponent<Rigidbody2D> (); 
		myAnimator = GetComponent<Animator> (); 		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (facingPlayer) { 
			h = -1; 
			Vector3 movement = new Vector3 (h*speed, transform.position.y, transform.position.z); 
			myRigidBody.velocity = movement; 
		}
	}

	void Flip() 
	{

	}
}
