using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Level : MonoBehaviour
{
   public void Level_0()
   {
        SceneManager.LoadScene("Boss_0");
   }

   public void Level_1()
   {
       SceneManager.LoadScene("Boss_1");
   }

   public void Level_2()
   {
        SceneManager.LoadScene("Boss_2");
   }

    public void Level_3()
    {
        SceneManager.LoadScene("Boss_3");
    }

    public void Level_4()
    {
        SceneManager.LoadScene("Boss_4");
    }

    public void Level_5()
    {
        SceneManager.LoadScene("Boss_5");
    }

    public void Level_6()
    {
        SceneManager.LoadScene("Boss_6");
    }
}
