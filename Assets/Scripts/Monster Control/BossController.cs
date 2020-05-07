using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
  

    [SerializeField]
    float moveSpeed = 2f;
    int waypointIndex = 7;
    float maxHealth;
    
    public Transform[] waypoints;
    public Slider bossHealth;
    public GameObject Protego;
   

    void Start()
    {
        maxHealth = GetComponent<Target>().health;
        for(int childIndex = 0; childIndex < waypointIndex; childIndex++)
        {
            waypoints[childIndex] = GameObject.Find("BossPath").transform.GetChild(childIndex).transform;
        }
        waypointIndex = 0;
        transform.position = waypoints[waypointIndex].transform.position;
    }

    void Update()
    {
        MoveBoss();
        HealthUpdate();

        if (GetComponent<Target>().health == 500)
        {
            StartCoroutine(Shield());
        }

       
    }

    void MoveBoss()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

        if (transform.position == waypoints[waypointIndex].transform.position)
        {
            waypointIndex += 1;
        }

        if (waypointIndex == waypoints.Length)
            waypointIndex = 0;
    }    
    void HealthUpdate()
    {
        float health = GetComponent<Target>().health;
        bossHealth.value = health / maxHealth;
        Debug.Log(health + "/" + maxHealth);
    }

    IEnumerator Shield()
    {
        Protego.SetActive(true);
        yield return new WaitForSeconds(5);
        Protego.SetActive(false);
    }
}
