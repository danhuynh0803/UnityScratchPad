using UnityEngine;
using System.Collections;

public class AimPlayer : MonoBehaviour {

	public Transform playerPos; 
	public float projSpeed = 20.0f;
	public GameObject projectile; 
	public float shotDelay;
	float timer;
	private Transform myTranform; 
	Rigidbody2D projRB; 
	
	void Awake() 
	{
		
	}	
	
	void Start () 
	{
		GameObject go = GameObject.FindGameObjectWithTag("Player");
		projRB = projectile.GetComponent<Rigidbody2D>();
		playerPos = go.transform;
		
		myTranform = GetComponent<Transform>();
		myTranform.LookAt(playerPos);
	}
	
	void Update () 
	{	
		timer += Time.deltaTime;
		if (timer >= shotDelay)
		{
			float step = projSpeed * Time.deltaTime; 
			Quaternion rotation = new Quaternion(0, 0, 0, 0);
			Instantiate(projectile, this.transform.position, rotation); 
			timer = 0.0f;
		}
	}
}
