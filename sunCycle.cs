using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sunCycle : MonoBehaviour
{
    /// <summary>
    ///  Drop the script on a directional light.
    ///  Press "sunset" key (defined in InputManager) to start rotation. 
    ///  Adjust speed and rotation limit
    /// </summary>
    public float speed = 10f;
    public float limit=180;
    
    public bool loop = false;
    bool stop = true;
    float Totangle =0;
    float slowspeed;

    private void Start()
    {
        slowspeed = speed / 2;
    }

    void Update()
    {    
        //Launch with key
        if (Input.GetButton("sunset")) { Debug.Log("Sunset ON: Speed="+speed+", limit= "+limit); stop = false; }
       
        //Rotation
        if (!stop)
        {
            transform.Rotate(speed * Time.deltaTime,0,0);
            Totangle += speed * Time.deltaTime;
            //slow down at golden hour
        if (Totangle > limit* 0.4f && !loop) speed =slowspeed ;
        }
        //stop at night
        if (Totangle > limit && !loop) 
        { 
            stop = true;
            speed *= 2;
        }


    }

}
