/*
 Script for controlling an object with the thrustmaster t300 playseat + steering wheel

 Input Manager Configuration
 --------- Horizontal --------
    #Type       Joystick Axis    
    #Axis       3rd Axis
    #Joy Num    Joystick 1
 --------- Vertical ----------
    #Type       Joystick Axis    
    #Axis       X Axis
    #Joy Num    Joystick 1
 --------- Fly ---------------
    #Type       Joystick Axis    
    #Axis       Y Axis
    #Joy Num    Joystick 1
------------------------------
*/
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;


public class PlayseatDrive : MonoBehaviour
{
    public float gasSpeed = 5;
    public float rotationSpeed = 100;
    public float flySpeed = 2;
    private float translation;
    private float rotation;
    private float elevation;


    void Update()
    {
        // Get the horizontal, vertical and fly axis.
        // Horizontal: Gas Pedal
        // Vertical: Steering wheel
        // Fly: Break Pedal 

        translation = (Input.GetAxis("Horizontal") * gasSpeed) - gasSpeed; // - gasSpeed: to have translation=0 at Axis=1
        rotation = Input.GetAxis("Vertical") * rotationSpeed;
        elevation = (Input.GetAxis("Fly") * flySpeed) - flySpeed; // - flySpeed: to have elevation=0 at Axis=1
        
        if ((translation != 0) | (rotation != 0) | (elevation != 0)) MoveObj();

    }

    void MoveObj()
    {
        // per frame -> per second
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        elevation *= Time.deltaTime;
        // Move translation along Z + Elevation along Y ;  multiply by -1 to get the forward direction
        transform.Translate(0, (elevation * (-1)), translation * (-1));
        // Rotate around Y
        transform.Rotate(0, rotation, 0);
    }

}