using UnityEngine;
using System.Collections;

public class AimMouse : MonoBehaviour {

	public GameObject projectile; 
	Rigidbody2D projRB; 
	// Use this for initialization
	void Start () {
		projRB = projectile.GetComponent<Rigidbody2D>(); 
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	public void Fire() 
	{
		Vector3 pos = Input.mousePosition; 
		pos.z = transform.position.z - Camera.main.transform.position.z; 
		pos = Camera.main.ScreenToWorldPoint(pos); 
		
		var q = Quaternion.FromToRotation(Vector3.up, pos - transform.position); 
		Instantiate(projectile, pos, q); 
		Vector2 dir = new Vector2 (0, -1);
		projRB.AddForce(dir * 200.0f); 	
	}
}
