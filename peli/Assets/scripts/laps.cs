using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private void Update()
    {
        laptime += Time.deltaTime;
        laptimer.text = "Lap time: " + laptime.ToString("F2");
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
}
