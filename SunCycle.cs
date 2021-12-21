using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sunCycle : MonoBehaviour
{
    /// <summary>
    ///  Drop the script on a directional light.
    ///  Press "sunset" key (defined in InputManager) to start rotation. 
    ///  Adjust speed and rotation limit
    ///  The script also fades the skybox image.
    /// </summary>
    [Range(0.0f, 30.0f)] public float speed = 10f;
    [Range(1.0f, 360.0f)] public float limit=180;
    
    public bool loop = false;
    public bool rotateSkybox = true;

    bool stop = true;
    float skyExposure=2;
    float slowspeed, expoLimit;
    float Totangle =0;
    int i = 0;

    private void Start()
    {
        //init
        slowspeed = speed / 2;
        skyExposure= RenderSettings.skybox.GetFloat("_Exposure");
        //Reset world expo
        RenderSettings.skybox.SetFloat("_Exposure", skyExposure);
        expoLimit = (skyExposure * 100) - 30f;

    }

    void Update()
    {
        //Launch with key
        if (Input.GetButtonDown("sunset")) 
        { 
            Debug.Log("Sunset ON: Speed="+speed+", limit= "+limit); 
            stop = false;
            StartCoroutine(FadeSkyBox());
        }
       
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

        //skybox rotation
        if (rotateSkybox) RenderSettings.skybox.SetFloat("_Rotation", Time.time);


    }

    IEnumerator FadeSkyBox()
    {   
        while(i < expoLimit)
        {
        i++;
        skyExposure = skyExposure - 0.01f;
        RenderSettings.skybox.SetFloat("_Exposure", skyExposure);
        yield return new WaitForSeconds(0.1f);
        }

    }

}
