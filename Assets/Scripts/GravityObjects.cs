using UnityEngine;
using System.Collections;

public class GravityObjects : MonoBehaviour {

	public float gravityForce; 						// Controls force of gravity

	Rigidbody myRigidbody; 
	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody> (); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
