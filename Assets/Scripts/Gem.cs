using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{

    public ScoreDisplay display;
    public Collider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        display = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreDisplay>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            display.AddScore(1);
            Object.Destroy(this.gameObject);
        }
    }
}
