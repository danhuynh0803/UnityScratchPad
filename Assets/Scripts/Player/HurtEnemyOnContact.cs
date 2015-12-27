using UnityEngine;
using System.Collections;

public class HurtEnemyOnContact : MonoBehaviour {
	
	public float knockbackY;
	PlayerController player;  
	Rigidbody2D playerRB; 
	
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController>();
		playerRB = player.GetComponent<Rigidbody2D>(); 
		
	}	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	// Hurt enemy on contact 
	void OnTriggerEnter2D(Collider2D other) 
	{	
		if (other.tag == "Enemy") 
		{
			playerRB.velocity = new Vector2(playerRB.velocity.x, knockbackY);	
			
			// Call enemy death 
			other.gameObject.GetComponent<EnemyDeath>().KillEnemy();
		}
	}
}
