using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    
    private Vector3 mouseDownPosition;
    public Data data;
   
    private void OnMouseDown()
    {
      
            mouseDownPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, transform.position.z));                        // Farenin objeye ilk týklamadaki pozisyok bilgisi alýyoruz
       
    }
    private void OnMouseDrag()
    {
        if (data.assemblyActive == false)
        {
            transform.position += Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, transform.position.z)) - mouseDownPosition;  // Objenin pozisyonunu farenin konum deðiþikliði kadar deðiþtiriyoruz
            mouseDownPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, transform.position.z));                        // Farenin pozisoynunu sürekli güncelliyoruz
            EventManager.selectMovingObject.Invoke(transform.gameObject);                                                                             // Seçilen obje süreklenirken ki event çalýþtýrýlýyor
        }
        
    }
    private void OnMouseUp()
    {
       
            EventManager.assemblyObject.Invoke(transform.gameObject);                                                                                   //Obje býrakýldýðý zaman montaj eventini çalýþtýrýyoruz
        
    }
}
