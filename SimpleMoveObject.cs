/*

Simple script for moving an object along the X (sides) and Z (forward) directions with the arrow keys 
- Horizontal  : X axis : left/right 
- Vertical    : Z axis : forward/back

*/

using UnityEngine;
using System.Collections;

public class SimpleMoveObject : MonoBehaviour
{

  public int moveSpeed=1;

  void Update()
  {
    // Translation along X and Z
    transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
  }
  
}
