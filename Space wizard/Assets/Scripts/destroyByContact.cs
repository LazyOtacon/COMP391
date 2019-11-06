using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyByContact : MonoBehaviour
{

    public GameObject explosion;


    void OnCollisionEnter2D(Collision2D other)
    {
        //instantiate our exposion prefab at the correct location

        Instantiate(explosion, transform.position, transform.rotation);


        //destroy this object AND the "other" object
        Destroy(other.gameObject); //laser
        Destroy(this.gameObject);
    }

}
