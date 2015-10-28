using UnityEngine;
using System.Collections;

public class PlatformController : MonoBehaviour {
	
	Rigidbody2D myRigidbody; 

	// Use this for initialization
	void Start () 
	{ 
		myRigidbody = GetComponent<Rigidbody2D>(); 
	}
	
	// Update is called once per frame
	void Update()
	{
	} 
}
