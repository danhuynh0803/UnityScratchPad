using UnityEngine;
using System.Collections;

public class GatherState : IAIState
{
	private readonly StatePatternWorker worker;

	private bool isFull = false; 		// Check if worker's capacity is full
	private bool isEmpty = true; 		// Check if capcity has been emptied out

	class Resource 
	{
		string name; 	// Name of resource
		int space;		// Space resource takes up. Relates to holding capacity
	}
		
	private Resource resource;

	public GatherState(StatePatternWorker statePatternWorker)
	{
		worker = statePatternWorker;
	}
		
	public void UpdateState()
	{
		Gather (resource);		// Gather designated resource
		Store ();		// Store resource in treasury
	}

	public void ToIdleState()
	{
		worker.currentState = worker.idleState;
	}

	public void ToGatherState() { Debug.Log ("Gathering"); }

	public void ToBuildState() 
	{
		worker.currentState = worker.buildState;
	}

	private void Gather(Resource resource) 
	{
		if (resource == null && isEmpty)			// Idleing when resource at location is depleted and worker has emptied contents to storage
			ToIdleState ();

		while (!isFull && (resource != null)) {
			
		}
	}

	private void Store() 
	{
		while (!isEmpty) {

		}
	}

	public void OnTriggerEnter2D(Collider2D other)
	{

	}

}
