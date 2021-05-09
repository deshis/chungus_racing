using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class daboom : MonoBehaviour
{

    public GameObject game;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "car")
        {
            game.GetComponent<AudioSource>().Play();
        }
    }

}
