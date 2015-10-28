using UnityEngine;
using System.Collections;

public class EnemyDeath : MonoBehaviour {
	
	public float deathTimer = 12.0f; 					// Time for object to be destroyed
	Animator myAnimator; 

	void Start() 
	{
		myAnimator = GetComponent<Animator> (); 
	}

	void OnTriggerExit2D(Collider2D other) 
	{
		// Play death animation and destroy object after a few seconds
		if (other.tag == "Player") 
		{
			myAnimator.SetBool ("isDead", true); 
			Destroy (this.gameObject, deathTimer * Time.deltaTime); 
		}
	}
}
