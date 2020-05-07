using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerAxis : MonoBehaviour
{
    public float speed = 10.0f;
    private float translation;
    private float straffe;
 
   

    // Use this for initialization
    void Start()
    {
        // turn off the cursor
        Cursor.lockState = CursorLockMode.None;
       
    }

    // Update is called once per frame
    void Update()
    {
        // Input.GetAxis() is used to get the user's input
        // You can furthor set it on Unity. (Edit, Project Settings, Input)
        translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        straffe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
     //   translation = Mathf.Clamp(translation, 3.2f, -3.3f);
        transform.Translate(straffe, 0, translation);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.6f, 1.6f), 0, Mathf.Clamp(transform.position.z, -3.4f, 3.2f));


        if (Input.GetKeyDown("escape"))
        {
            // turn on the cursor
            Cursor.lockState = CursorLockMode.None;
        }

       
    }
   
}
