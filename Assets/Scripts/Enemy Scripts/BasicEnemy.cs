using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms.Impl;

public class BasicEnemy : MonoBehaviour
{
	[Header("Variables you can change")]

	public float enemyHealth; //health of the enemy
	public float enemyDamage, attackRange;
	[Tooltip("Change the score of the enemy generates")] public int ScoreAmount;
	private Transform playerObject;
	private ScoreManager scoreManager;

	NavMeshAgent navAgent;

	// Start is called before the first frame update
	void Start()
	{
		playerObject = GameObject.FindWithTag("Player").transform;
		navAgent = GetComponent<NavMeshAgent>();
		scoreManager = GameObject.Find("UICanvas").GetComponent<ScoreManager>();
	}

	// Update is called once per frame
	void Update()
	{
		navAgent.destination = playerObject.position;
		if(Vector3.Distance(playerObject.position, transform.position) <= attackRange){
			playerObject.GetComponent<PlayerHealth>().TakeDamage(enemyDamage);
			Destroy(gameObject);
		}
	}

	public void TakeDamage(float amount){
		enemyHealth -= amount;
		if(enemyHealth <= 0f){
			scoreManager.AddScore(ScoreAmount);
			Destroy(gameObject);
		}
	}
}
