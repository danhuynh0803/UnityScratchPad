using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour {
	
	public float speed = 5.0f; 							// Speed of the projectile
	public float delay = 2.0f; 							// Delay between each shot
	
	Rigidbody2D myRb2d; 
	// Use this for initialization
	void Start () {
		myRb2d = GetComponent<Rigidbody2D>(); 
	}
	
	// Update is called once per frame
	void Update () {
		myRb2d.velocity = new Vector2(speed, myRb2d.velocity.y); 
	}
	
}
