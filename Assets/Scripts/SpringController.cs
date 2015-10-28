using UnityEngine;
using System.Collections;

public class SpringController : MonoBehaviour {

	public float springForce = 10.0f; 
	public float delay = 2.0f; 
	public Animator myAnimator; 
	AudioSource audio; 

	Rigidbody2D playerRB; 
	Vector2 springMovement; 
	Vector2 springPos; 

	// Use this for initialization
	void Start () 
	{
		GameObject player = GameObject.FindGameObjectWithTag("Player"); 
		myAnimator = GetComponent<Animator>(); 
		playerRB = player.GetComponent<Rigidbody2D>(); 
		audio = GetComponent<AudioSource>(); 
	}
	
	// Update is called once per frame
	void Update () 
	{ 
		springMovement = new Vector2(playerRB.velocity.x, springForce); 
	}

	void OnTriggerEnter2D(Collider2D other) 
	{ 
		if (other.tag == "Player") 
		{ 
			myAnimator.SetBool("isSprung", true); 
			playerRB.velocity = springMovement; 
		}
	} 

	void OnTriggerExit2D(Collider2D other) 
	{ 
		if (other.tag == "Player") 
		{ 
			myAnimator.SetBool ("isSprung", false); 
			audio.Play(); 
		} 
	} 
}

