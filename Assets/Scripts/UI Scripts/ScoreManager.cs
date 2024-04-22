using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.SearchService;

public class ScoreManager : MonoBehaviour
{

	public TMP_Text ScoreContainer;
	private int baseScore;


	public void AddScore(int score) //Call this in order to add score 
	{
		baseScore += score;
		UpdateScore();
	}

	public void SubtractScore(int score) //Call this in order to subtract score
	{
		baseScore -= score;
		UpdateScore();
	}

	void UpdateScore() //Call this is order to update the UI
	{
		ScoreContainer.text = "SCORE: " + baseScore;
	}
	

}
