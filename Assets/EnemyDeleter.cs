using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeleter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        Debug.Log("Something in collider");
        if(other.gameObject.CompareTag("BasicEnemy")){
            Debug.Log("enemy hit");
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("RangeEnemy")){
            Destroy(other.gameObject);
        }
    }
}
