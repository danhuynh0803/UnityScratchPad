using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public float speed;  				// Control enemy movement speed
	private Animator myAnimator;  				// Control animations 
	public bool facingLeft = true; 				// Check if facing left
	
	public bool onWall; 						// Check if enemy is colliding with wall
	public LayerMask whatIsWall; 				
	private Rigidbody2D myRigidBody; 	
	private Collider2D myCollider; 
	
	float h; 									// Horizontal movement direction
	Vector3 playerPos; 							// Player position
	Vector3 enemyPos; 							// Enemy position 
	float distance;								// Distance from player and enemy 

	PlayerController player; 
	LevelController levelController; 
	
	 
	
	// Use this for initialization
	void Start() 
	{
		myRigidBody = GetComponent<Rigidbody2D> (); 
		myAnimator = GetComponent<Animator> (); 		
		myCollider = GetComponent<Collider2D>();
		player = FindObjectOfType<PlayerController>();
		levelController = FindObjectOfType<LevelController>();
	}
	
	
	void FixedUpdate () 
	{
		if (facingLeft) { 
			h = -1; 	
		} 
		else {
			h = 1;
		}
		Vector3 movement = new Vector3 (h*speed, transform.position.y, transform.position.z); 
		myRigidBody.velocity = movement; 
	}
	
	// Update is called once per frame
	void Update() 
	{
		enemyPos = GetComponent<Transform>().position;
		playerPos = player.transform.position; 
		distance = Vector3.Distance(enemyPos, playerPos);
		
		onWall = Physics2D.IsTouchingLayers(myCollider, whatIsWall);
		if (onWall) 
		{ 
			Flip ();
		}
	}
	
	// Flip object when encountering a wall
	void Flip() 
	{
		Vector3 theScale = transform.localScale; 
		theScale.x *= -1; 
		transform.localScale = theScale;
		if (facingLeft) 
			facingLeft = false; 
		else 
			facingLeft = true;
	}
}