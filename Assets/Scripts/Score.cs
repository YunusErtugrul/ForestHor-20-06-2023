using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{

    public Text scoreText;
    public int score;

    void Start()
    {
        scoreText.text = "Baby Found: " + score; // To make sure the score text is accurate
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = "Baby Found: " + score;
        if (score >= 10)
        { // We only need to check if the score is high enough when it increases, not every frame.
            SceneManager.LoadScene(3);
        }
    }
}   