using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms.Impl;

public class RangeEnemy : MonoBehaviour
{

    public float enemyHealth;
    public float attackRange, attackRate;
    public int ScoreAmount;
    
    public GameObject enemyProjectile;
   
    private ScoreManager scoreManager;
    private float attackDelay = 1f;
    private Transform playerObject;

    private NavMeshAgent navAgent;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindWithTag("Player").transform;
        navAgent = GetComponent<NavMeshAgent>();
        scoreManager = GameObject.Find("UICanvas").GetComponent<ScoreManager>();
        navAgent.stoppingDistance = attackRange;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(playerObject);
        navAgent.destination = playerObject.position;
        if(Vector3.Distance(playerObject.position, transform.position) <= attackRange){
            if(Time.time > attackDelay){
                
                Attack();
            }
            
        }
    }

    void Attack(){
        GameObject clone = Instantiate(enemyProjectile, transform.position, transform.rotation);
        Destroy(clone, 10f);
        attackDelay = Time.time + attackRate;
        
    }

    public void TakeDamage(float amount){
        enemyHealth -= amount;
        if(enemyHealth <= 0f){
            scoreManager.AddScore(ScoreAmount);
            Destroy(gameObject);
        }
    }
}
