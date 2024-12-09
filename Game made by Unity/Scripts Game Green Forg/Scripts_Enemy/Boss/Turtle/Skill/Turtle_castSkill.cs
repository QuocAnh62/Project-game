using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Turtle_castSkill : MonoBehaviour
{
    [SerializeField] private GameObject[] Skill;
    public float timeCastSkill;

    private void OnEnable()
    {
        StartCoroutine(cast());
    }

    private void Cast_Skill()
    {
        GameObject skill = Instantiate(Skill[Random.Range(0, Skill.Length)], transform.position, Quaternion.identity);
    }

    IEnumerator cast()
    {
        yield return new WaitForSeconds(4f);
        while (true)
        {
            GameObject skill = Instantiate(Skill[Random.Range(0, Skill.Length)], transform.position, Quaternion.identity);
            skill.transform.parent = transform;
            yield return new WaitForSeconds(timeCastSkill);
        }
    }


}
