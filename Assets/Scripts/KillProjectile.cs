using UnityEngine;
using System.Collections;

public class KillProjectile : MonoBehaviour {

	
	// Use this for initialization
	void Start () {
		KillDelay();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void KillDelay()
	{
		StartCoroutine("KillDelayCo");
	}
	
	IEnumerator KillDelayCo() 
	{
		yield return new WaitForSeconds(10.0f);
		Destroy(this.gameObject); 
	}
	
}
