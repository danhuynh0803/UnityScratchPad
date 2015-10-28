using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	private bool facingRight = true; 			// For determining direction player is facing 
	public float speed = 10.0f; 				// Speed of movement
	public float jumpForce = 10.0f; 			// How high player can jump 
	public bool grounded;						// Check if player is grounded
	public bool onEnemy; 						// Check if player is stepping on an enemy
	public bool onWall; 						// Check if player is touching wall
	Animator animator; 							// Control player animations 
	
	public LayerMask whatIsGround;  			// Determine surface layers
	public LayerMask whatIsEnemy; 
	public LayerMask whatIsWall; 				
	
	private Rigidbody2D myRigidBody;			// Control player physics   
	private Collider2D myCollider; 				// Control collider triggers 
	private Transform myTransform; 				// Control player transformations

	public Transform firePoint; 				// Point of projectile launch
	public GameObject projectile; 				// projectile being fired

	float h; 									// Controls when player is moving 
	bool horizontalEnable = true; 
	bool doubleJump = true; 
	
	
	// Use this for initialization
	void Start () 
	{
		myRigidBody = GetComponent<Rigidbody2D> (); 
		myCollider = GetComponent<Collider2D> (); 	 
		animator = GetComponent<Animator> (); 
		myTransform = GetComponent<Transform> ();  
	}

	void FixedUpdate() 
	{ 
		/*
		* flip actor
		if (h < 0 && facingRight) 
			Flip ();
		else if (h > 0 && !facingRight) 
			Flip (); 
		*/
	} 

	// Update is called once per frame
	void Update () 
	{
		myRigidBody.rotation = 0.0f; 
		if (horizontalEnable) 
			h = Input.GetAxis ("Horizontal"); 
		myRigidBody.velocity = new Vector2 (h * speed, myRigidBody.velocity.y);

		// check if collider is touching ground layer
		grounded = Physics2D.IsTouchingLayers (myCollider, whatIsGround); 
		onWall = Physics2D.IsTouchingLayers(myCollider, whatIsWall); 
		onEnemy = Physics2D.IsTouchingLayers (myCollider, whatIsEnemy);  
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.W)) 
		{
			
		    if (grounded || onEnemy || doubleJump) 
			{ 
				if (Input.GetKeyDown(KeyCode.W))		// If input is W, perform a soft jump
			  	{ 
					myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, jumpForce*.75f); 
					doubleJump = false;
				} 
				else 
				{ 
					myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, jumpForce); 	 
					doubleJump = false;  
				}
			} 
			/*
			// Disable horizontal movement when character is touching wall 
			if (onWall && !grounded) 
				horizontalEnable = false;
			else 
				horizontalEnable = true; 
			*/ 
		}
		
		if (grounded) doubleJump = true; 						// Allow player to dble jump again after touching ground
		
		if (h != 0) {  // check if player is moving 
			animator.SetBool ("isMoving", true); 
		} else { 
			animator.SetBool ("isMoving", false); 
		}

		if (Input.GetKeyDown("s"))
		{ 
			animator.SetBool("inputDown", true); 
		} else { 
			animator.SetBool("inputDown", false); 
		} 
		animator.SetBool ("isGrounded", grounded); 
		
		if(Input.GetButtonDown("Fire1"))
		{ 
			Instantiate(projectile, firePoint.position, firePoint.rotation);
		} 
		
	}

	void Flip() 
	{ // switch direction of the player
		// switch the label player is facing
		facingRight = !facingRight; 

		Vector3 theScale = transform.localScale; 
		theScale.x *= -1; 
		transform.localScale = theScale; 
	}

	void OnTriggerEnter2D(Collider2D other)
	{ 
		if (other.tag == "Enemy") 
		{ 

		} 
	} 
}

