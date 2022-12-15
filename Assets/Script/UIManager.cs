using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject panel;
    public Data data;
    

    private void OnEnable()
    {
        EventManager.successfulPanel += SuccessfulPanel; 
    }
    private void OnDisable()
    {
        EventManager.successfulPanel -= SuccessfulPanel;
    }
    public void PanelClosed()                                                      // Panel kapatma fonksiyonu
    {
        panel.gameObject.SetActive(false);                                         // Panel Gizleniyor
      
    }
    public void SuccessfulPanel()                                                  // Tebrikler mesajýný içeren Panel fonksiyonu
    {
        if(data.pinClip1AssamblyCheck==true && data.pinClip2AssamblyCheck == true && data.rodAssamblyCheck == true && data.rodBearingCapSideAssamblyCheck == true &&         // Bütün montaj iþlemlerinin kontrolü
            data.rodBearingRodSideAssamblyCheck == true && data.rodBolt1AssamblyCheck == true && data.rodBolt2AssamblyCheck == true && data.rodCapAssamblyCheck == true )
        {
            panel.gameObject.SetActive(true);                                     // Panel gösteriliyor
            
        }
        
    }

}
