using UnityEngine;
using System.Collections;

public class BuildState : IAIState 
{
	private StatePatternWorker worker;

	public BuildState(StatePatternWorker statePatternWorker)
	{
		worker = statePatternWorker;
	}

	public void UpdateState()
	{
		
	}

	public void ToIdleState()
	{
		worker.currentState = worker.idleState;
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
}
