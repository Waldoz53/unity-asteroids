using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject asteroid;

    private int score;
    private int lives;
    private int wave;
    private int hiscore;
    private int asteroidsRemaining;
    private int increaseEachWave = 4;

    public Text scoreText;
    public Text hiscoreText;
    public Text livesText;
    public Text wavesText;
    // Start is called before the first frame update
    void Start()
    {
        hiscore = PlayerPrefs.GetInt("hiscore", 0);
        startGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void startGame()
    {
        score = 0;
        lives = 3;
        wave = 1;

        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + lives;
        hiscoreText.text = "High Score: " + hiscore;
        wavesText.text = "Wave: " + wave;

        spawnAsteroids();
    }

    void spawnAsteroids()
    {
        destroyExistingAsteroids();

        asteroidsRemaining = (wave * increaseEachWave);

        for (int i = 0; i < asteroidsRemaining; i++)
        {
            Instantiate(asteroid, new Vector3(Random.Range(-9f, 9f), Random.Range(-5f, 5f), 0), Quaternion.Euler(0, 0, Random.Range(0f, 359f)));
        }

        wavesText.text = "Waves: " + wave;
    }

    public void incrementScore()
    {
        score++;

        scoreText.text = "Score: " + score;

        if (score > hiscore)
        {
            hiscore = score;
            hiscoreText.text = "High score: " + hiscore;

            PlayerPrefs.SetInt("hiscore", hiscore);
        }

        if (asteroidsRemaining < 1)
        {
            wave++;
            spawnAsteroids();
        }
    }

    public void decrementLives()
    {
        lives--;
        livesText.text = "Lives: " + lives;

        if (lives < 1)
        {
            startGame();
        }
    }

    public void decrementAsteroids()
    {
        asteroidsRemaining--;
    }

    public void splitAsteroids()
    {
        asteroidsRemaining += 2;
    }

    void destroyExistingAsteroids()
    {
        GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Large Asteroid");

        foreach (GameObject current in asteroids)
        {
            GameObject.Destroy(current);
        }

        GameObject[] asteroids2 = GameObject.FindGameObjectsWithTag("Small Asteroid");

        foreach (GameObject current in asteroids2)
        {
            GameObject.Destroy(current);
        }
    }

}
