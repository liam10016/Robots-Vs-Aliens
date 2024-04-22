using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    Rigidbody rigidbody;
    public float bulletSpeed;
    public float bulletDamage;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
    }

    void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            other.transform.GetComponent<PlayerHealth>().TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
    }
}
