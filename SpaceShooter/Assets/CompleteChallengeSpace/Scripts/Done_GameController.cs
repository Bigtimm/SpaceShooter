using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class Done_GameController : MonoBehaviour
{
    private Done_PlayerController playerController;
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public float timePassed;
    private float speed = 30.0f;
    
    public Text winText;
    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    public Text hardText;
    
    public static bool winGame;
    public bool gameOver;
    private bool restart;
    private bool hard;
    private int score;
    private AudioSource Music;
    public AudioClip music_background;
    public AudioClip win_music;
    public AudioClip gameover_music;

    void Start()
    {
        Music = GetComponent<AudioSource>();
        Music.clip = music_background;
        winGame = false;
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        winText.text = "";
        hardText.text = "";
        score = 0;
        timePassed = 0;
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

        if (Input.GetKeyDown("enter"))
        {
            hard = !hard;
            if(hard)
            {
                hard = true;
                waveWait = 0;
            }
            
            else
            {
                hard = true;
                waveWait = 6;
            }
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
    }
    void UpdateScore()
    {
        hardText.text = "Enter for Hardmode";
        scoreText.text = "Points: " + score;
        if (score >= 100)
        {
            winText.text = "You Win! Game Created By Timmothy Tapia";
            winGame = true;
            gameOver = true;
            restart = true;
            winGame = true;
            Music.clip = win_music; Music.Play();
            playerController.winMove();
        }
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
        
        if (gameOver == true)
        {
            Music.clip = gameover_music; Music.Play();
        }
    }
}