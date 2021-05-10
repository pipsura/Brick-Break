using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int lives;
    public int score;

    public Text livesText;
    public Text scoreText;

    public bool gameOver;

    public GameObject gameOverPanel;

    public int numberOfBricks;

    private void Start()
    {
        livesText.text = "Lives - " + lives;
        scoreText.text = "Score - " + score;
        numberOfBricks = GameObject.FindGameObjectsWithTag("Block").Length;

        Debug.Log(numberOfBricks);
    }


    private void Update()
    {
        
    }

    public void UpdateLives(int changeLives)
    {
        lives += changeLives;

        if (lives <= 0)
        {
            lives = 0;
            GameOver();
        }

        livesText.text = "Lives - " + lives;
    }

    public void UpdateScore(int changeScore)
    {
        score += changeScore;
        scoreText.text = "Score - " + score;
    }

    void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
    }

    

    public void UpdateNumberOfBricks()
    {
        numberOfBricks--;
        if(numberOfBricks <= 0)
        {
            GameOver();
        }
    }
}
 