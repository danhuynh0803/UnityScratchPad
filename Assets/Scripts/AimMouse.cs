using UnityEngine;
using System.Collections;

public class AimMouse : MonoBehaviour {

	public Vector2 mousePosition; 
	public GameObject projectile; 
	public float projSpeed = 200.0f; 
	private float step; 
	
	Rigidbody2D projRB; 
	// Use this for initialization
	void Start () {
		projRB = projectile.GetComponent<Rigidbody2D>(); 
		mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}
	
	// Update is called once per frame
	void Update () {
		step = projSpeed * Time.deltaTime; 
	}
	
	public void Fire() 
	{
		projRB.transform.position = Vector2.MoveTowards(projRB.transform.position, mousePosition, step);
	}
	
	public void Strike() 
	{
		Vector3 pos = Input.mousePosition; 
		pos.z = transform.position.z - Camera.main.transform.position.z; 
		pos = Camera.main.ScreenToWorldPoint(pos); 
		
		Vector2 dir = new Vector2 (0, -1);
		projRB.AddForce(dir * 200.0f); 	
	}
}
