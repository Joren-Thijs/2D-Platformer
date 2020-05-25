using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinnerDisplay : MonoBehaviour
{
    public Text winnerText;

    public bool winner = false;

    void Start()
    {
        winnerText.enabled = winner;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void IsWinner()
    {
        winner = true;
        winnerText.enabled = winner;
    }
}
