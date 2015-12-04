using UnityEngine;
using System.Collections;

public class OrcDamage : MonoBehaviour {
	
	private Animator myAnimator; 
	// Use this for initialization
	void Start () {
		myAnimator = GetComponent<Animator>(); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D other) 
	{
		Debug.Log("enter trigger");
		if (other.tag == "Player") 
		{
			myAnimator.SetBool("isSteppedOn", true); 
		}
	}
	
	void OnTriggerExit2D(Collider2D other) 
	{
		myAnimator.SetBool ("isSteppedOn", false);
	}
}
