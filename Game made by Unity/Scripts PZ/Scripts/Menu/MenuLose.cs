using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLose : MonoBehaviour
{
    public void Button_Reset()
    {        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Button_NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
