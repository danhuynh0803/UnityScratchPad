using UnityEngine;
using System.Collections;

public class GrabItem : MonoBehaviour {

	private bool hasItem = false; 					
	private Rigidbody2D itemRB; 
	private PlayerController player;
	
	public float speed; 
	public float angle; 
	
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (hasItem) 
		{
			itemRB.transform.position = this.transform.position; 
		}
		
		if (Input.GetMouseButtonDown(0))
		{
			Throw();
		}
		
		else if (Input.GetMouseButtonDown(1)) 
		{
			Drop();
		}
	}
	
	void OnTriggerEnter2D(Collider2D item) 
	{
		if (item.tag == "Item" && hasItem == false)
		{
			PickUp(item);
		}

		
	}
	
	void PickUp(Collider2D item) 
	{
		itemRB = item.gameObject.GetComponent<Rigidbody2D>();
		itemRB.Sleep();
		itemRB.transform.position = this.transform.position; 
		hasItem = true;
	}
	
	// Drop item at currect position
	void Drop()
	{
		hasItem = false; 
	}
	
	void Throw() 
	{	
		float direction = 0;
		if (player.facingRight == true)
			direction = 1; 
		else 
			direction = -1;
		
		Vector2 launch = new Vector2(direction * speed * Mathf.Cos(angle),
									  speed * Mathf.Sin (angle)); 
									  
		hasItem = false;
	}
}
