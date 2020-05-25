using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private CharacterController2D player;

    private bool tookDamage = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController2D>();

    }

    void FixedUpdate()
    {
        // Stop the player and add force upwards when hurt
        if (tookDamage == true)
        {
            Debug.Log("Test");
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            player.GetComponent<Rigidbody2D>().angularVelocity = 0;
            tookDamage = false;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            //Debug.Log("Took damage!");
            player.TakeDamage(1);
            tookDamage = true;

            StartCoroutine(player.Knockback(0.03f, 40));
        }
    }
}
