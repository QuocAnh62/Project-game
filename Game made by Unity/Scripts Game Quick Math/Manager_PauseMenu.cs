using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager_PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    public void OpenPauseMenu()
    {
        SystemPlayAudio.instance.PlayEffect(SystemPlayAudio.instance.button_Effect);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Buuton_Resume()
    {
        SystemPlayAudio.instance.PlayEffect(SystemPlayAudio.instance.button_Effect);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Buuton_Restart()
    {
        SystemPlayAudio.instance.PlayEffect(SystemPlayAudio.instance.button_Effect);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Buuton_MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Buuton_Exit()
    {
        Application.Quit();
    }
}
