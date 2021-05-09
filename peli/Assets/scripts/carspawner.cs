using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carspawner : MonoBehaviour
{

    public GameObject spawn1;
    public GameObject spawn2;

    public GameObject cam1;
    public GameObject cam2;

    public GameObject sexhaver;
    public GameObject sexhaver2;
    public GameObject idiot;
    public GameObject idiot2;
    public GameObject driftmasheen;
    public GameObject driftmasheen2;
    public GameObject kuutio;
    public GameObject kuutio2;
    public GameObject chunguslada;
    public GameObject chunguslada2;

    string car1;
    string car2;


    public void getcars(string[] yeah)
    {
        car1 = yeah[0];
        car2 = yeah[1];
        spawncars();
    }

    public void spawncars()
    {
        switch (car1)
        {
            case "drift möskiinerrrrrrrrr":
                GameObject a = Instantiate(driftmasheen, spawn1.transform);
                cam1.GetComponent<CameraFollow>().setTarget(a);
                break;
            case "mobil de la chungus":
                GameObject b = Instantiate(chunguslada, spawn1.transform);
                cam1.GetComponent<CameraFollow>().setTarget(b);
                break;
            case "idi*t":
                GameObject c = Instantiate(idiot, spawn1.transform);
                cam1.GetComponent<CameraFollow>().setTarget(c);
                break;
            case "kuutiokaara":
                GameObject d = Instantiate(kuutio, spawn1.transform);
                cam1.GetComponent<CameraFollow>().setTarget(d);
                break;
            case "s*x_haver":
                GameObject e = Instantiate(sexhaver, spawn1.transform);
                cam1.GetComponent<CameraFollow>().setTarget(e);
                break;
        }

        switch (car2)
        {
            case "drift möskiinerrrrrrrrr":
                GameObject f = Instantiate(driftmasheen2, spawn2.transform);
                cam2.GetComponent<CameraFollow>().setTarget(f);
                break;
            case "mobil de la chungus":
                GameObject g = Instantiate(chunguslada2, spawn2.transform);
                cam2.GetComponent<CameraFollow>().setTarget(g);
                break;
            case "idi*t":
                GameObject h = Instantiate(idiot2, spawn2.transform);
                cam2.GetComponent<CameraFollow>().setTarget(h);
                break;
            case "kuutiokaara":
                GameObject i = Instantiate(kuutio2, spawn2.transform);
                cam2.GetComponent<CameraFollow>().setTarget(i);
                break;
            case "s*x_haver":
                GameObject j = Instantiate(sexhaver2, spawn2.transform);
                cam2.GetComponent<CameraFollow>().setTarget(j);
                break;
        }
    }
}
