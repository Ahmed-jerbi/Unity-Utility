using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraLinearMvt : MonoBehaviour
{
    public int speed = 2;
    private bool firstStart = false;


    void Update()
    {
        //------ increase the speed 
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            speed += 2;
        }
        
        //------ decrease the speed
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
                speed -= 2;

        }
       
        //----- START movement with "SPACE"
            if (Input.GetKeyDown("space") || firstStart)
        {
            firstStart = true;
            // Move the camera forward along its z axis 1 unit/second.
            transform.Translate(0,0, Time.deltaTime * speed);

        }
       
        //----- Exit Game on "ESCAPE"
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }



    }

}
