using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public GameObject[] enemyPrefabs;
	public float spawnRate;
	public float spawnDistance;
	public int enemyCount;
	GameObject player;
	bool active = false;
	bool spawned = false;

	void Start(){
		//InvokeRepeating("Spawn", 0.5f, spawnRate);
		player = GameObject.FindWithTag ("Player");
	}
	void Update()
	{
		float dist = Vector3.Distance (player.transform.position, transform.position);
		
		
		if (dist < spawnDistance && !spawned)
		{
			spawned = true;
			active = true;

		}
		
		if(active){
			active = false;
			StartCoroutine(Spawn());	
		}
		
	}

	private IEnumerator Spawn(){

		for(int i = 0; i < enemyCount; i++)
		{
			Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], transform.position, Quaternion.identity);
			//enemyCount++;
			yield return new WaitForSeconds(spawnRate);
		}
	}
}
