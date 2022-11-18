using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;



public class LoadFileTexture : MonoBehaviour
{

    public string filePath;
    /// <summary>
    /// Load Background Image from a local file on runtime. You can trigger this function by a button / external script
    /// </summary>
    public void LoadBackgroundPNG()
    {
        Texture2D tex = null;
        byte[] fileData;

        if (File.Exists(filePath))
        {
            fileData = File.ReadAllBytes(filePath);
            tex = new Texture2D(2, 2);
            tex.LoadImage(fileData); //auto-resize
        }                       
        gameObject.GetComponent<Renderer>().material.mainTexture = tex;
    }
}