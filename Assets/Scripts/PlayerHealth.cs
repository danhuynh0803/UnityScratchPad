using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public int startingHealth = 100; 
	public int currentHealth;
	public int lives; 
	public Slider healthSlider; 
	public Image damageImage; 
	public AudioClip deathClip; 
	public float flashSpeed = 5f; 
	public Color flashColor = new Color(1f, 0f, 0f, 0.1f); 
	public float knockbackX; 		
	public float knockbackY;
	public float knockbackLength; 
	private float knockbackCount; 
		
	LevelController levelController; 
	PlayerController player; 
	Rigidbody2D playerRB; 
	bool isDead; 
	bool damaged; 
	
	
	void Start () 
	{
		levelController = FindObjectOfType<LevelController>(); 
		player = GetComponent<PlayerController>(); 
		playerRB = player.GetComponent<Rigidbody2D>();
		currentHealth = startingHealth;
	}
	
	
	void Update () 
	{
		if (damaged) 
		{
			damageImage.color = flashColor; 
		}
		else 
		{
			damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime); 
		}
		damaged = false; 
	}
	
	public void TakeDamage(int amount) 
	{
		damaged = true; 
		currentHealth -= amount; 
		healthSlider.value = currentHealth; 
		knockbackCount = knockbackLength; 
		if (currentHealth <= 0 && !isDead)
		{
			levelController.Respawn();		 	// Respawn player
			// Death();
		}
		
		if (knockbackCount >= 0) 
		{
			playerRB.velocity = new Vector2(-knockbackX, knockbackY);
		}
		
		knockbackCount -= Time.deltaTime; 
	}
}