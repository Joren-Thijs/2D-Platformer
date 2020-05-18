using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    private int maxHealth = 6;
    private int currentHealth = 6;
    public Text healthText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        healthText.text= "HEALTH : " + currentHealth.ToString();

        // DEBUG FUNCTION
        if (Input.GetKeyDown(KeyCode.E)) {
            TakeDamage(1);
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            Heal(1);
        }
    }

    void TakeDamage(int damageAmount) {
        //Debug.Log("Took damage: " + damageAmount + " point(s).");
        currentHealth -= damageAmount;
        if (currentHealth < 0) currentHealth = 0;
    }

    void Heal(int healAmount) {
        //Debug.Log("Healed for: " + healAmount + " point(s).");
        currentHealth += healAmount;
        if (currentHealth > 6) currentHealth = 6;
    }
}