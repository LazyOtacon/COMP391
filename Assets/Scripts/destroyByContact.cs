using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyByContact : MonoBehaviour
{
    


    public GameObject explosion;
    public int scoreValue = 10; //set score value for astroids

    private GameController gameControllerScript; //refrence to the game controller script on my game controller object

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController"); //looks for every object with the GameController tag and returns information
        
        if(gameControllerObject != null) 
        {
            //i have found a gamecontroller object with tag GameController
            gameControllerScript = gameControllerObject.GetComponent<GameController>();
        }
        if(gameControllerObject == null)
        {
            //script is not attached to object
            Debug.Log("cannot find script on game controller object");
        }
    }



    void OnCollisionEnter2D(Collision2D other)
    {
        //instantiate our exposion prefab at the correct location

        Instantiate(explosion, transform.position, transform.rotation);

        if (other.gameObject.CompareTag("Player"))
        {
            gameControllerScript.GameOver();
        }

        //update the score
        gameControllerScript.AddScore(scoreValue);


        //destroy this object AND the "other" object
        Destroy(other.gameObject); //laser
        Destroy(this.gameObject);
    }

}
