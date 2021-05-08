using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{

    float chungustimer = 0f;

    [SerializeField] Text racetime;




    void Update()
    {
        chungustimer += Time.deltaTime;

        racetime.text="Race time: "+ chungustimer.ToString("F2");
    }
}
