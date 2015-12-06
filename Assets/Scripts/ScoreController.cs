using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreController : MonoBehaviour {

	public GUIText scoreTotal; 
	private int score = 0; 
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		scoreTotal.text = "Score: " + score; 
	}
	
	void addScore(int score)
	{
		this.score += score; 
	}
}
