





using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    public int amount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

 void OnTriggerEnter3D(BoxCollider coll)
    {
        if (coll.tag == "Player")
        {
           coll.gameObject.GetComponent<PlayerMovement>().MoveSpeed += amount;
            Destroy(gameObject);
        }
    }
}