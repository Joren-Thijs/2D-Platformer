using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{

    private int score = 0;
    public Text scoreText;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "SCORE : " + score.ToString();
    }

    public void AddScore(int addScore)
    {
        score += addScore;
        if (score < 0) score = 0;
    }

}
