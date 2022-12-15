using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    
    private Vector3 mouseDownPosition;
    public Data data;
   
    private void OnMouseDown()
    {
      
            mouseDownPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, transform.position.z));
       
    }
    private void OnMouseDrag()
    {
        if (data.assemblyActive == false)
        {
            transform.position += Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, transform.position.z)) - mouseDownPosition;
            mouseDownPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, transform.position.z));
            EventManager.selectMovingObject.Invoke(transform.gameObject);

        }
        
    }
    private void OnMouseUp()
    {
        
            EventManager.assemblyObject.Invoke(transform.gameObject);
        
    }
}
