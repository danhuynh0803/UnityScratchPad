using UnityEngine;
using System.Collections;

public class Bandaid : MonoBehaviour {
	
	PlayerHealth playerHealth; 
	bool isBandOn; 
	// Use this for initialization
	void Start () {
		playerHealth = FindObjectOfType<PlayerHealth>(); 
		this.gameObject.GetComponent<Renderer>().material.color -= new Color(0, 0, 0, 100f); 		
		isBandOn = false; 
	}
	
	// Update is called once per frame
	void Update () {
		if (playerHealth.currentHealth <= 50 && isBandOn == false) 
		{
			this.gameObject.GetComponent<Renderer>().material.color += new Color(0, 0, 0, 100f);
			isBandOn = true; 
		}
		else if (playerHealth.currentHealth > 50 && isBandOn == true);
		{
			this.gameObject.GetComponent<Renderer>().material.color -= new Color(0, 0, 0, 100f);
			isBandOn = false; 
		}
	}
}