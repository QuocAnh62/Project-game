using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{

    public GameObject shop;
    public GameObject level;
    public GameObject option;
    public void play()
    {
        SceneManager.LoadScene("Main_Map");
    }

    public void Level()
    {
        level.SetActive(true);
    }

    public void Shop()
    {
        shop.SetActive(true);
    }
    public void Option()
    {
        option.SetActive(true);
    }
    



    public void TurnOffLevel()
    {
        level.SetActive(false);
    }


    public void TurnOffShop()
    {
       shop.SetActive(false);
    }

    public void TurnOffOption()
    {
        option.SetActive(false);
    }


    public void Quit()
    {
        Application.Quit();
    }

  
}
