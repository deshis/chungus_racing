using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carspawner : MonoBehaviour
{

    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject victoryspawn;

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
    string victorycar;
    int playerWon;


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
            case "drift masheen":
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
            case "drift masheen":
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

    public void getvictorycar(string yeah)
    {
        victorycar = yeah;

        Debug.Log(yeah);
        Debug.Log(yeah.Substring(yeah.Length-2));

        if(victorycar.Substring(yeah.Length-9).Equals(" 2(Clone)")){
            victorycar = victorycar.Substring(0, yeah.Length-9);
            playerWon = 2;
        }else{
            playerWon = 1;
            victorycar = victorycar.Substring(0, yeah.Length-7);
        }

        spawnvictorycar();
    }

    private void spawnvictorycar(){
        Debug.Log(victorycar);
        switch (victorycar)
        {
            case "drift masheen":
                GameObject a = Instantiate(driftmasheen, victoryspawn.transform);
                break;
            case "chungus mobil":
                GameObject b = Instantiate(chunguslada, victoryspawn.transform);
                break;
            case "DaCar":
                GameObject c = Instantiate(idiot, victoryspawn.transform);
                break;
            case "monke":
                GameObject d = Instantiate(kuutio, victoryspawn.transform);
                break;
            case "sex haver":
                GameObject e = Instantiate(sexhaver, victoryspawn.transform);
                break;
        }

        GameObject.Find("god").GetComponent<playerwhowonxd>().SendMessage("ads", "Player    " + playerWon);
    }
    
}
