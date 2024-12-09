using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Pause_Menu : MonoBehaviour
{
    
    public GameObject pauseMenu;
    TMP_Text Text_Rocket;
    private Shoot_Bullet_Rocket bullet;
    private CoolDownRocket coolDown;
    

    private float CoolDown;
    private void Start()
    {
        bullet = GameObject.FindAnyObjectByType<Shoot_Bullet_Rocket>().GetComponent<Shoot_Bullet_Rocket>();

        Text_Rocket = GameObject.Find("NumberOfRocket")?.GetComponent<TMP_Text>();

        coolDown = GameObject.FindAnyObjectByType<CoolDownRocket>().GetComponent<CoolDownRocket>();

        ShowRocket();
    }

   
    public void PauseMenu()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }


    public void Main_Menu()
    {       
        SceneManager.LoadScene("Main_Menu");        
        Time.timeScale = 1;
        HeartSystem.Health = 4;
        CourotineCoint_3th.coint_3h.CheckCoint();
    }


    public void Continue()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    
    public void Setting()
    {
        // Do What ??!
    }

    public void Quit()
    {
        CourotineCoint_3th.coint_3h.CheckCoint();
        Application.Quit();
    }


    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        HeartSystem.Health = 4;
        CourotineCoint_3th.coint_3h.CheckCoint();
    }


    public void Shoot_Bullet()
    {
        bullet.shoot();
    }
  

    public void Shoot_Rocket()
    {
        int n_rocket = PlayerPrefs.GetInt("Rocket");
        if (n_rocket > 0)
        {

            if (CoolDown <= 0) // CoolDown shoot Rocket
            {
                bullet.shootRocket();
                coolDown.Usespell();
                n_rocket -= 1;
                Text_Rocket.text = n_rocket.ToString();
                PlayerPrefs.SetInt("Rocket", n_rocket);
                CoolDown = 8f;
            }
            else return;

        }
        else return;

    }

    public void ShowRocket()
    {
        int S_rocket = PlayerPrefs.GetInt("Rocket");
        Text_Rocket.text = S_rocket.ToString();
    }


    private void Update()
    {
        //time.CurrentCoolDown -= Time.deltaTime;
        CoolDown -= Time.deltaTime;
    }

}
