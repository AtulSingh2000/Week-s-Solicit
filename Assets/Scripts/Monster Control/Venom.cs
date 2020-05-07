﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Venom : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject target;
    private float moveSpeed;
    private GameObject FPSScene;
    public float rotFrequency = 50f;

    Vector3 directionToTarget;

    // Start is called before the first frame update
    void Start()
    {
        FPSScene = GameObject.Find("FPSSceneControl");
        rb = GetComponent<Rigidbody>();
        moveSpeed = Random.Range(10f, 20f);
        MoveSpit();

    }

    private void OnCollisionEnter(Collision collision)
    {
        //health trigger
        if (collision.gameObject.CompareTag("Player"))//tag == "Player")
        {
            FPSScene.GetComponent<FPSSceneControl>().CamShake();
            //Debug.Log("health--");
            PlayerController.Health -= 15;
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Venom"))
        {
            Destroy(gameObject);
        }
    }

    void MoveSpit()
    {
        target = GameObject.FindGameObjectWithTag("MainCamera");
        if (target != null)
        {
            directionToTarget = (target.transform.position - transform.position).normalized;
            rb.velocity = new Vector3(directionToTarget.x * moveSpeed, directionToTarget.y * moveSpeed, directionToTarget.z * moveSpeed);
        }
        else
            rb.velocity = Vector3.zero;
    }
}
