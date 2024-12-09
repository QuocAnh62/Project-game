using UnityEngine;

public class Health_Player : Boss_Kill_Player
{
    [Header("=================================")]
    [SerializeField] private float timeNotDie;
    [SerializeField] private float coolDown_NotDie;
    public bool IsAlive => currenthealth_Player > 0;
     
    protected void FixedUpdate()
    {
        timePlayer_NotReceiveDame();
        Time_MinusHealthByBoss();
    }

    private void timePlayer_NotReceiveDame()
    {
        timeNotDie -= Time.deltaTime;
        if (timeNotDie <= 0)
        {
            timeNotDie = 0;
        }
    }

    public void Player_MinusHealth(int dame)
    {      
        if(timeNotDie <= 0)
        {
            AudioManager.Instance.PlayEffect(AudioManager.Instance.Player_Hit);
            StartCoroutine(Anim_Hit()); // do animation player hit 

            currenthealth_Player -= dame;

            Active_Heart(Health = currenthealth_Player); // minus Image heart 
            PlayerDie(currenthealth_Player);   // check health player alive or not         

            timeNotDie = coolDown_NotDie; // if time not die equal 0, set time not die equal cool down ttime not die
        }             
    }

    public void Player_plusHealth(int health)
    {
        AudioManager.Instance.PlayEffect(AudioManager.Instance.Player_Health);
        currenthealth_Player += health;

        NotGreater_5(currenthealth_Player, Health);
        Active_Heart(Health = currenthealth_Player);
    }

    private void NotGreater_5(int health, int heart)
    {
        if (health >= maxHealth_Player && heart >= maxHealth_Player)
        {
            currenthealth_Player = maxHealth_Player;
            Health = maxHealth_Player;
        }
    }

    private void PlayerDie(int health)
    {
        if(health <= 0)
        {
            GameControll.Instance.Die();
            Reset_Health();           
        }
    }

    
}
