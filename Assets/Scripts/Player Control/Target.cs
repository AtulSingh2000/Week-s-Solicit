using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 20f;
    public GameObject explosionEffect;
    
    private static int killScore = 0, killCoins = 0, killCount = 0;

    private int awardedScore, awardedCoins;

    private GameObject FPSSceneController;
    private void Start()
    {
        FPSSceneController = GameObject.Find("FPSSceneControl");
    }
    public void TakeDamage(float DamageAmount)
    {
        health -= DamageAmount;
        if(health <= 0f)
        {
            Die();
        }
    }
    void Die()
    {
        killCount++;
        if(GetComponent<MonsterController>())
        {
            ScoreMultiplier(GetComponent<MonsterController>().creatureType);
        }
        else if(GetComponent<BossController>())
        {
            
            ScoreMultiplier('Z');
        }
       
        if(GetComponent<BossController>())
            Instantiate(explosionEffect, new Vector3(0, 1.75f, -0.5f), Quaternion.identity);
        else
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        //Debug.Log("scored: " + killScore);
    }
    void ScoreMultiplier(char thisType)
    {
        switch(thisType)
        {
            case 'A':
                awardedScore = 1;
                awardedCoins = 2;
             
                break;
            case 'B':
                awardedScore = 5;
                awardedCoins = 4;
              
                break;
            case 'C':
                awardedScore = 10;
                awardedCoins = 6;
              
                break;
            case 'D':
                awardedScore = 50;
                awardedCoins = 8;
               
                break;
            case 'Z':
                awardedScore = 100;
                awardedCoins = 20;
              
                break;
            default:
                awardedScore = 0;
                awardedCoins = 0;
               
                break;
        }
        killScore += awardedScore ;
        killCoins += awardedCoins;
       
        FPSSceneControl.CoinCountUpdate(awardedCoins);
     
    }
    public static int GetScoreCount()
    {
        return killScore;
    }
    public static void SetScoreCount(int arg)
    {
        killScore = arg;
    }
    public static int GetCoinCount()
    {
        return killCoins;
    }
    public static void SetCoinCount(int arg)
    {
        killCoins = arg;
    }
   
}
