using UnityEngine;
using System.Collections;

public interface IAIState
{	
	// Run update function within the state
	void UpdateState(); 		

	/* Have worker walk around idley after two conditions: 
		 1. Worker depletes resource at that location
		 2. Worker finishes building */
	void ToIdleState();

	// Gather resources state -- gather material specified by the player and store it within the treasuries
	void ToGatherState();

	// Build state -- build specified structure
	void ToBuildState();

	void OnTriggerEnter2D(Collider2D other);
}