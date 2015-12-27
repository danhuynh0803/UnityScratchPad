using UnityEngine;
using System.Collections;

public class EnemyDeath : MonoBehaviour {
	
	public float deathTimer; 					// Time for object to be destroyed
	public int scoreValue; 
	
	LevelController levelController; 
	
	Animator myAnimator; 
	Rigidbody2D enemyRB;  
	
	void Start() 
	{
		enemyRB = GetComponent<Rigidbody2D>();
		levelController = FindObjectOfType<LevelController>();
		myAnimator = GetComponent<Animator> (); 
	}
	
	public void KillEnemy() 
	{
		myAnimator.SetBool("isDead", true); 
		//this.gameObject.GetComponent<Collider2D>().enabled = false; 
		ScoreController.AddScore(scoreValue);
		Destroy(this.gameObject, deathTimer);  
	}
}
