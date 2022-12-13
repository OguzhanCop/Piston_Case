using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    
    private Vector3 mouseDownPosition;
   
    private void OnMouseDown()
    {
        
       mouseDownPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, transform.position.z));
        
    }
    private void OnMouseDrag()
    {
    
        transform.position +=Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, transform.position.z)) - mouseDownPosition;
        mouseDownPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, transform.position.z));
       
    }
}
