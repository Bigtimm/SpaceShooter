using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class Done_GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    
    public Text winText;
    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    
    public bool winGame;
    public bool gameOver;
    private bool restart;
    private int score;

    void Start()
    {
        winGame = false;
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        winText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

		if (winGame)
		{
            GetComponent<AudioSource>().Play();
		}

        if (gameOver)
        {
            GetComponent<AudioSource>().Play();
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'T' for Restart";
                restart = true;
                break;
            }

            if (winGame)
            {
                restartText.text = "Press 'T' for Restart";
                restart = true;
                break;
            }

        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
        
        if (score == 100)
        {
            winText.text = "You Win! Game Created By Timmothy Tapia";
            winGame = true;
        }

        if (score > 100)
        {
            gameOverText.text = "Game Over!";
            gameOver = true;
        }

        if (score < 0)
        {
            gameOverText.text = "Game Over!";
            gameOver = true;
        }

    }
    void UpdateScore()
    {
        scoreText.text = "Points: " + score;
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
}