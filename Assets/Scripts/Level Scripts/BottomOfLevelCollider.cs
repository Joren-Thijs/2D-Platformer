using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BottomOfLevelCollider : MonoBehaviour
{
    public Collider2D collider;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
