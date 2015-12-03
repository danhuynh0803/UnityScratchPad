using UnityEngine;
using System.Collections;

public class DestroyPlatform : MonoBehaviour {

	public float destroyDelay = 3.0f; 						// Time until platform is destroyed
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.tag == "Player") 
		{
			Destroy(this.gameObject, destroyDelay);
		}
	}
}
