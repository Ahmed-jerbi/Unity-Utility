/*

Simple script for moving an object along the X (sides) and Z (forward) directions with the arrow keys + Rotate with Mouse Axis
- Horizontal  : X axis : left/right 
- Vertical    : Z axis : forward/back

*/

using UnityEngine;
using System.Collections;

public class SimpleMoveObject : MonoBehaviour
{

  public int moveSpeed=1;
  public int rotSpeed=1;

  void Update()
  {
    // Translation along X and Z
    transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
    
    //Rotation around X and Y
    transform.Rotate(rotSpeed * Input.GetAxis("Mouse Y"), rotSpeed * Input.GetAxis("Mouse X"), 0);
    
  }
  
}
