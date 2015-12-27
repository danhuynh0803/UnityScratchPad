using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {
	
	public float respawnDelay = 5.0f; 
	
	public GameObject playerSpawnPoint;
	private PlayerController player;
	
	public GameObject deathParticle; 
	public GameObject respawnParticle;
	
	PlayerHealth playerHealth; 
	
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController>();
		playerHealth = FindObjectOfType<PlayerHealth>();
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	public void Respawn() 
	{
		StartCoroutine("RespawnCo");
	}
	
	public IEnumerator RespawnCo() 
	{
		Instantiate(deathParticle, player.transform.position, player.transform.rotation);
		//player.enabled = false;
		player.GetComponent<Renderer>().enabled = false; 
		Debug.Log ("Player respawn");
		yield return new WaitForSeconds(respawnDelay);
		
		player.enabled = true; 
		player.GetComponent<Renderer>().enabled = true; 
		player.transform.position = playerSpawnPoint.transform.position;
		Instantiate(respawnParticle, playerSpawnPoint.transform.position, playerSpawnPoint.transform.rotation);	
		playerHealth.currentHealth = 100;
		playerHealth.healthSlider.value = playerHealth.currentHealth; 
	}
	
	public void waitDelay() 
	{ 
		StartCoroutine(wait ());
	}
	
	IEnumerator wait() 
	{ 
		yield return new WaitForSeconds(respawnDelay);
		Debug.Log("Delay respawn");
	}
}
