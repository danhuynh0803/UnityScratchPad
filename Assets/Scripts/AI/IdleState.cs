using UnityEngine;
using System.Collections;

public class IdleState : IAIState
{

	private readonly StatePatternWorker worker;

	public IdleState(StatePatternWorker statePatternWorker)
	{
		worker = statePatternWorker;
	}

	public void UpdateState()
	{
		
	}

	public void ToIdleState() {
		Debug.Log ("Idleing");
	}

	public void ToGatherState()
	{
		worker.currentState = worker.gatherState;
	}

	public void ToBuildState()
	{
		worker.currentState = worker.buildState;
	}

	public void OnTriggerEnter2D(Collider2D other)
	{

	}

	private void Movement(float distance) 
	{

	}



}
