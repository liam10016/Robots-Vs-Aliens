using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [Tooltip("Replace this bullet with your own object")] public GameObject bulletPrefab;
    [Tooltip("The point where the bullet is spawned")] public GameObject firePoint;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            //Fires on left mouse button
            GameObject bulletClone = Instantiate(bulletPrefab, firePoint.transform.position, Quaternion.identity);
            Destroy(bulletClone, 5f); //deletes the bullet after a certain amount of time. 
        }
        
    }
}
