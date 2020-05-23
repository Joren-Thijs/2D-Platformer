using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{

    private int score = 0;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "SCORE : " + score.ToString();

        // DEBUG FUNCTION
        if (Input.GetKeyDown(KeyCode.P))
        {
            AddScore(1);
        }  
    }

    public void AddScore(int addScore)
    {
        Debug.Log("Collected gem: added" + addScore + " point(s).");
        score += addScore;
        if (score < 0) score = 0;
    }
}
