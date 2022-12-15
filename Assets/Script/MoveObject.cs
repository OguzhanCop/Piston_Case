using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    
    private Vector3 mouseDownPosition;
    public Data data;
   
    private void OnMouseDown()
    {
      
            mouseDownPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, transform.position.z));                        // Farenin objeye ilk t�klamadaki pozisyok bilgisi al�yoruz
       
    }
    private void OnMouseDrag()
    {
        if (data.assemblyActive == false)
        {
            transform.position += Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, transform.position.z)) - mouseDownPosition;  // Objenin pozisyonunu farenin konum de�i�ikli�i kadar de�i�tiriyoruz
            mouseDownPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, transform.position.z));                        // Farenin pozisoynunu s�rekli g�ncelliyoruz
            EventManager.selectMovingObject.Invoke(transform.gameObject);                                                                             // Se�ilen obje s�reklenirken ki event �al��t�r�l�yor
        }
        
    }
    private void OnMouseUp()
    {
       
            EventManager.assemblyObject.Invoke(transform.gameObject);                                                                                   //Obje b�rak�ld��� zaman montaj eventini �al��t�r�yoruz
        
    }
}
