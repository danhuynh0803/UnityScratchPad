using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreController : MonoBehaviour {
 
	private static int score;
	
	Text text; 

	void Start () {
		text = GetComponent<Text>();
		
		// Reset score
		score = 0; 
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Score:" + score; 
	}
	
	public static void AddScore(int value)
	{
		score += value; 
	}
}
