using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    //hold score
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnWaves());
    }

    // Update is called once per frame
    void Update()
    {

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



        }



    }
}

