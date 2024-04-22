using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{

    public float playerHealth;

    public Slider healthSlider;
    void Start()
    {
        healthSlider.maxValue = playerHealth;
    }

    void Update()
    {
        healthSlider.value = playerHealth;
    }
    
    public void TakeDamage(float damageAmount){
        playerHealth -= damageAmount;
        if(playerHealth <= 0f){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
