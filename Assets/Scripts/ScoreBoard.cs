using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {



	[SerializeField] int score ;
	Text scoreText;

	// Use this for initialization
	void Start () {
		scoreText = GetComponent<Text>();
		scoreText.text = score.ToString();
	}

	public void OnScoreHit(int scorePerHit){
		score += scorePerHit;
		scoreText.text = score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
