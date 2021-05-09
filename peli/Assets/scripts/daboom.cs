using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class daboom : MonoBehaviour
{

    public GameObject game;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            game.GetComponent<AudioSource>().Play();
        }
    }

}
