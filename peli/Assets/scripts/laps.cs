using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class laps : MonoBehaviour
{
    [SerializeField] Transform finishline;

    [SerializeField] Transform checkpoint_1;
    [SerializeField] Transform checkpoint_2;
    [SerializeField] Transform checkpoint_3;

    [SerializeField] Text lapamount;
    [SerializeField] Text laptimer;
    [SerializeField] Text latestlap;


    float laptime;
    float cpvalue;
    float thelaps;
    [SerializeField] float NumberOfCheckpoints;



    private void Start()
    {
        lapamount.text = "Lap: 0";
        laptimer.text = "Lap time: ";
        latestlap.text = "Latest lap: N/A";



    }


    private void Awake()
    {
        if (GameObject.Find("aivohalvaus"))
        {
            checkpoint_1 = GameObject.Find("aivohalvaus").GetComponent<maketimerswork>().cp1.transform;
            checkpoint_2 = GameObject.Find("aivohalvaus").GetComponent<maketimerswork>().cp2.transform;
            checkpoint_3 = GameObject.Find("aivohalvaus").GetComponent<maketimerswork>().cp3.transform;
            finishline = GameObject.Find("aivohalvaus").GetComponent<maketimerswork>().finishline.transform;


            if (gameObject.transform.name.Substring(gameObject.transform.name.Length-8).Equals("2(Clone)")) {
                lapamount = GameObject.Find("aivohalvaus").GetComponent<maketimerswork>().amount2;
                laptimer = GameObject.Find("aivohalvaus").GetComponent<maketimerswork>().timer2;
                latestlap = GameObject.Find("aivohalvaus").GetComponent<maketimerswork>().latest2;
            }
            else
            {
                lapamount = GameObject.Find("aivohalvaus").GetComponent<maketimerswork>().amount;
                laptimer = GameObject.Find("aivohalvaus").GetComponent<maketimerswork>().timer;
                latestlap = GameObject.Find("aivohalvaus").GetComponent<maketimerswork>().latest;
            }

        }
    }
    private void Update()
    {
        laptime += Time.deltaTime;
        laptimer.text = "Lap time: " + laptime.ToString("F2");

        if (thelaps >= 1)
        {
            GameObject.Find("chungus").GetComponent<databetweenscenes>().SendMessage("getinfo",transform.gameObject.name);
            SceneManager.LoadScene("win");
        }
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag.Equals("checkpoint"))
        {

            if (other.name == "checkpoint1" && cpvalue == 0)
            {
                cpvalue = 1;
            }
            else if (other.name == "checkpoint2" && cpvalue == 1)
            {
                cpvalue = 2;
            }
            else if (other.name == "checkpoint3" && cpvalue == 2)
            {
                cpvalue = 3;
            }

            Debug.Log(cpvalue);
        }

        else if(other.tag.Equals("finishline")&&cpvalue==NumberOfCheckpoints)
        {
            thelaps++;
            lapamount.text = "Lap: " + thelaps.ToString();
            cpvalue = 0;
            latestlap.text = "Latest lap: "+laptime.ToString("F2");
            laptime = 0;
        }
    }

    public Transform GetCPValue(){
        switch(cpvalue){
            case 1:
                return checkpoint_1;
            case 2:
                return checkpoint_2;
            case 3:
                return checkpoint_3;
        }

        return finishline;
    }

}
