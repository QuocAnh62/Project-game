using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Turtle_Skill_1st : MonoBehaviour
{
    private List<State_Spikes> spikes = new List<State_Spikes>();
    private List<Spikes_FlowPlayer> spikes_FlowPlayer = new List<Spikes_FlowPlayer>();
    private List<State_Spikes> check_spikes_3rd = new List<State_Spikes>();

    [SerializeField] private GameObject spikes_Perfab;
    [SerializeField] protected float time;
    [SerializeField] protected float resetTime;
    int a = 0;


    private void Start()
    {
        Spawn_Spikes();
    }

    private void OnDisable()
    {
        Destroy(this.gameObject);
    }


    private void Update()
    {
        active_spikes();       
    }

    private void active_spikes() /******* Active spike_followPlayer and state_spikes(health) => enabled = true *******/
    {      
        time -= Time.deltaTime;

        for (int i = 0; i <= spikes_FlowPlayer.Count; i++)
        {           
            if (a >= spikes_FlowPlayer.Count) break;
            if (time <= 0)
            {               
                a++;
                spikes_FlowPlayer[a - 1].enabled = true;
                spikes[a -1].enabled = true;
                time = resetTime;
                // Debug.Log(name + " " + spikes_Count);             
            }
        }       
    }



    private void Spawn_Spikes() /* ******* Loop spawn Spikes_Floow player ******* */
    {      
        for (int i = 0; i < 4; i++) 
        {
            GameObject spikes = Instantiate(spikes_Perfab, transform.position + new Vector3(i, 0, 0), transform.rotation); 
            spikes.transform.parent = transform;

            add_spikes(spikes,i); // Add spikes on list <State_Spikes> and <Spikes_FollowPlayer>

        }        
    }


    private void add_spikes(GameObject spikes, int i)
    {
        Spikes_FlowPlayer spikesFlow = spikes.GetComponent<Spikes_FlowPlayer>();
        State_Spikes Sta_spikes = spikes.GetComponent<State_Spikes>();
        State_Spikes check_Spikes = spikes.GetComponent<State_Spikes>();

        if (spikesFlow != null || Sta_spikes != null)
        {
            this.spikes_FlowPlayer.Add(spikesFlow);
            this.spikes.Add(Sta_spikes);
        }
        if (check_Spikes != null && i == 4 - 1)
        {
            this.check_spikes_3rd.Add(check_Spikes);
        }
    }


}
