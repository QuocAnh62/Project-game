using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish_Line_1st : MonoBehaviour
{
    [SerializeField] GameObject joysitck;
    [SerializeField] GameObject speed_Up;
    [SerializeField] private Player_Moving player_moving;

    private void TriggerLine_1st()
    {
        player_moving.isFinishLine_1st = true;

        joysitck.SetActive(false);
    }

    private IEnumerator ShowSpeedUp()
    {
        yield return new WaitForSeconds(1f);
        speed_Up.SetActive(true);

        yield return new WaitForSeconds(3f);
        speed_Up.SetActive(false);
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log(Parameter_Manager.Instance.current_Stamina);
            TriggerLine_1st();  
            StartCoroutine(ShowSpeedUp());
        }
    }
}
