using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Creat_ButtonReset : MonoBehaviour
{
    [MenuItem("Helpers/Restart Scene #R ")]
    private static void RestartScene()
    {
        var currentSecen = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentSecen.name);
    }
}
