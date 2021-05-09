using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class databetweenscenes : MonoBehaviour
{

    public Dropdown dropdown1;
    public Dropdown dropdown2;
    public Dropdown dropdown3;

    string player1car;
    string player2car;
    string track;

    string playerWon;
    string winTime;

    string singleplayercar;

    public Dropdown spdropdown1;
    public Dropdown spdropdown2;

    bool carsspawned = false;
    bool carsspawned2 = false;

    public void getinfo(string player)
    {
        playerWon = player;
    }


    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    public void checkMultiplayer()
    {
        player1car = dropdown1.options[dropdown1.value].text;
        player2car = dropdown2.options[dropdown2.value].text;
        track = dropdown3.options[dropdown3.value].text;
        Debug.Log(player1car);
        Debug.Log(player2car);
        Debug.Log(track);

        SceneManager.LoadScene(track);

    }


  /*  public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        string[] hassuarrayxd = { player1car, player2car };

        if (scene.name=="testirata")
        {
            GameObject.Find("spawner").GetComponent<carspawner>().SendMessage("getcars", hassuarrayxd);
        }
    }*/

    public void checkSingleplayer()
    {
        singleplayercar = spdropdown1.options[spdropdown1.value].text;
        track = spdropdown2.options[spdropdown2.value].text;
        Debug.Log(singleplayercar);
        Debug.Log(track);
    }

    public void Update()
    {
        /*
        if (GameObject.Find("god") != null)
        {
            GameObject.Find("god").GetComponent<playerwhowonxd>().SendMessage("ads", playerWon);
        }
        */

        if (GameObject.Find("spawner") != null && !carsspawned)
        {
            string[] hassuarrayxd = { player1car, player2car };
            GameObject.Find("spawner").GetComponent<carspawner>().SendMessage("getcars", hassuarrayxd);
            carsspawned = true;



        }
        if (GameObject.Find("winspawner") != null && !carsspawned2){
            GameObject.Find("winspawner").GetComponent<carspawner>().SendMessage("getvictorycar", playerWon);
            carsspawned2 = true;
        }
    }

    /*  private void changePlayer1Car(int car)
      {
          player1car = car.ToString();
      }
      */

}
