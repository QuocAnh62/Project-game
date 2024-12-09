using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_menu : MonoBehaviour
{
    [SerializeField] private GameObject ui_Setting;
    public GameObject pauseMenu;
    bool pause = true;
    bool setting = false;

    private void Update()
    {
        PauseMenu();
        Allow_ShootBullet();
        Close_AudioSetting();
    }


    public void PauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pause)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;           
            pause = false;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pause == false)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            pause = true;
        }
    }


    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void Countine()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }


    public void Setting()
    {
        ui_Setting.SetActive(true);
        pauseMenu.SetActive(false);
         
        Time.timeScale = 0;

        setting = true;
        pause = true;  //set pause equal true because of not close pause Menu
    }

    public void Close_AudioSetting()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && setting == true)
        {
            ui_Setting.SetActive(false);
            pauseMenu.SetActive(true);

            Time.timeScale = 0;

            setting = false;
            pause = false; // set pause equal false because of close Ui menu Setting audio, then we can close pause menu

        }
    }



    // check if time scale = 0 not shot , if time scale = 1 allow shot
    private void Allow_ShootBullet()
    {
        if(Time.timeScale == 0) Data_Player.Instance.deset_eagle.IsShoot = false;

        else Data_Player.Instance.deset_eagle.IsShoot = true;
    }

}
