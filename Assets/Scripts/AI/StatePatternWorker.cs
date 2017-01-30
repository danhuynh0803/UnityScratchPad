using UnityEngine;
using System.Collections;

public class StatePatternWorker : MonoBehaviour 
{
	public IdleState idleState;
	public GatherState gatherState;
	public BuildState buildState;
	public IAIState currentState;

	private void Awake() 
	{
		idleState = new IdleState (this);
		gatherState = new GatherState (this);
		buildState = new BuildState (this);
	}

	
	void Start()
	{
		currentState = idleState;			// Starting state
	}		

	void Update()
	{
		currentState.UpdateState ();	
	}
		
	public void OnTriggerEnter2D(Collider2D other)
	{
		currentState.OnTriggerEnter2D (other);
	}

}
