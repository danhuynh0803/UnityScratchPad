using UnityEngine;
using System.Collections;

public class ApplyGrav : MonoBehaviour {

	public float gravity = 1f; //Multiplier for gravity.
	public float maxGravities = 8f; //Max amount of objects within the horizon at any given time.
	public bool fadeGravity; //Whether or not to fade the gravity the further you get from the planet.
	public float gravityAtHorizon = 0.5f; //How much weaker gravity is at the horizon. 0.5 is 50%
	public float horizonDistance; //The radius of the large circle collider.
	Rigidbody2D[] forceArrayRB; //Array of RigidBodys currently within the horizon.
	
	void Start () {
		forceArrayRB = new Rigidbody2D[(int)maxGravities];
	}
	
	void FixedUpdate () {
		if (forceArrayRB.Length >= 1) {
			MakeForce();
		}
		
	}
	
	void MakeForce() {
		int num = 0;
		foreach (Rigidbody2D r in forceArrayRB) {
			if(r != null) {
				
				//Finds direction that points the RigidBody to the planet.
				Vector3 gForce = gameObject.transform.position - r.transform.position;
				//Normalizes direction.
				gForce.Normalize();
				
				if(fadeGravity) { //Lerps the strength of the gravity if fading gravity is enabled.
					float dist = Vector2.Distance(r.position,
					                              gameObject.transform.position);
					dist /= horizonDistance; //Normalizes dist.
					gForce.x = Mathf.Lerp(gForce.x,gForce.x * gravityAtHorizon,dist);
					gForce.y = Mathf.Lerp(gForce.y,gForce.y * gravityAtHorizon,dist);
				}
				r.AddForce(((Vector2)gForce * 9.81f) * gravity); //Applies the force to the RigidBody.
			}
			num += 1;
		}
	}
	
	void OnTriggerEnter2D(Collider2D col) { //Adds the colliding RigidBody to the first available slot in ForceArrayRB[]
		Rigidbody2D crb = col.transform.gameObject.GetComponent<Rigidbody2D> ();
		if (crb) {
			bool applied = false;
			int num = 0;
			foreach (Rigidbody2D g in forceArrayRB) {
				if (!applied && g == null) {
					forceArrayRB [num] = crb;
					applied = true;
				}
				num += 1;
			}
		}
		
	}
	
	void OnTriggerExit2D(Collider2D col) { //Removes the colliding RigidBody from ForceArrayRB[]
		Rigidbody2D crb = col.transform.gameObject.GetComponent<Rigidbody2D> ();
		if (crb) {
			bool removed = false;
			int num = 0;
			foreach (Rigidbody2D g in forceArrayRB) {
				if (!removed && g == forceArrayRB [num]) {
					forceArrayRB [num] = null;
					removed = true;
				}
				num += 1;
			}
		}
		
	}
	
}