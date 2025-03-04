using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaittingToPlay : MonoBehaviour
{
    [SerializeField] private GameObject button_PlusSpeed;
    [SerializeField] private GameObject joysick;
    [SerializeField] private List<GameObject> wait_321;

    private float time_ReadyToShowUIButton = 3f;

    private void Start()
    {
        StartCoroutine(ShowButton_SpeedUp());      
    }    


    private IEnumerator ShowButton_SpeedUp() // show Button Speed Up
    {
        yield return new WaitForSeconds(time_ReadyToShowUIButton); // After 3 second show button Speed Up and UI 3 2 1 
        button_PlusSpeed.SetActive(true);
        StartCoroutine(Wait321());

        yield return new WaitForSeconds(3f); // when it show button SpeedUp after 3 second Inactive button SpeedUp
        button_PlusSpeed.SetActive(false);
        joysick.SetActive(true);              
    }

    private IEnumerator Wait321()
    {
        foreach (GameObject obj in wait_321)
        { 
            obj.SetActive(true);
            yield return new WaitForSeconds(1f);

            foreach(GameObject Obj in wait_321)
            {
                obj.SetActive(false);
            }

        }
    }

}
