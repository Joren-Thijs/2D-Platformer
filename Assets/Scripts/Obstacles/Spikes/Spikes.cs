using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private CharacterController2D player;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController2D>();

    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.CompareTag("Player")) {
            //Debug.Log("Took damage!");
            player.TakeDamage(1);

            StartCoroutine(player.Knockback(0.03f, 100, player.transform.position));
        }
    }
}
