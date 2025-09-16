using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChickenRun : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(IsActiveObj());
    }

    private void FixedUpdate()
    {
        Move();      
    }
    

    private void Move()
    {
        if (this.transform.rotation.y == 0)
        {
            this.transform.position -= new Vector3(6.5f, 0, 0);
        }
        else
        {
            this.transform.position += new Vector3(6.5f, 0, 0);
        }
    }

    private IEnumerator IsActiveObj()
    {
        yield return new WaitForSeconds(4f);
        this.gameObject.SetActive(false);
    }

    public void chickenPlayEffect()
    {
        SystemPlayAudio.instance.PlayEffect(SystemAudioInput.instance.chicken_Effect);
    }
}
