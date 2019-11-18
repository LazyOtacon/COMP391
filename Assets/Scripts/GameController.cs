using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //controll the spawn of hazards
    [Header("wave settings")]

    //public GameObject[] hazard; //that is how you make an array of items


    public GameObject hazard; //what are we spawning?
    public Vector2 spawnValue; //where do we spawn the hazards?
    public int hazardCount; //how many hazards per wave?
    public float startWait; //how long till first wave?
    public float spawnWait; //how long between each hazard in wave
    public float waveWait; //how long between each wave

    [Header("HUD Options")]
    //adding these allows the game controller to find the text needed by sending it to them directly
    public Text scoreText;
    public Text restartText;
    public Text gameOverText;


    //Player Score
    private int score = 0;
    private bool gameOver, restart;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = restart = false; //super facny way of setting 2 variables
        StartCoroutine(spawnWaves());
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        if (restart)
        {
            //listens for the R key to be pushed down
            if (Input.GetKeyDown(KeyCode.R))
            {
                //Restart the game
                // THE OLD WAY OF RESTARTING A SCENE
                //Application.LoadedLevel("game");

                //THE NEW WAY USE THIS ONE
                //SceneManager.LoadScene("SampleScene");


                //THIS IS THE BEST WAY TO LOAD A SCENE
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    //create a coroutine fuction

    IEnumerator spawnWaves()
    {
        //delay the frist wave by a period of time
        yield return new WaitForSeconds(startWait);

        while (true)
        {  //how game starts

            for (int i = 0; i < hazardCount; i++)
            {
                Vector2 spawnPostion = new Vector2(spawnValue.x, Random.Range(-spawnValue.y, spawnValue.y));


                Instantiate(hazard, spawnPostion, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.gameObject.SetActive(true);
                restart = true;

                break;
            }

        }



    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        //Debug.Log("Score: " + score);
        scoreText.text = "Score: " + score;
        UpdateScoreText();
    }

    void UpdateScoreText() //method that updates the score
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver() //method that turns on the game over text
    {
        gameOverText.gameObject.SetActive(true);
        gameOver = true;
    }




}

