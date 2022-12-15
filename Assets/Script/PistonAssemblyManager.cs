using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistonAssemblyManager : MonoBehaviour
{
    [SerializeField]
    GameObject pinClip1;
    [SerializeField]
    GameObject pinClip2;
    [SerializeField]
    GameObject piston;
    [SerializeField]
    GameObject rod;
    [SerializeField]
    GameObject rodBearingCapSide;
    [SerializeField]
    GameObject rodBearingRodSide;
    [SerializeField]
    GameObject rodBolt1;
    [SerializeField]
    GameObject rodBolt2;
    [SerializeField]
    GameObject rodCap;
    [SerializeField]
    GameObject wristPin;
    [SerializeField]
    GameObject pistonParent;



    public Data data;

    private void OnEnable()
    {
        EventManager.selectMovingObject += SelectMovingObject;
    }
    private void OnDisable()
    {
        EventManager.selectMovingObject -= SelectMovingObject;
    }


    void SelectMovingObject(GameObject movingObject)                                                            // Sürüklenen objenin bilgisi dýþarýdan gelýyor ve buna göre fonksiyonlar çalýþtýrýlýyor
    {
        switch (movingObject.name)
        {
            
            case "pin_clip_1":
                PinClip1AssemblyControl(movingObject);
                break;
            case "pin_clip_2":
                PinClip2AssemblyControl(movingObject);
                break;
            case "piston":
                
                break;
            case "rod":
                RodAssemblyControl(movingObject);
                break;
            case "rod_bearing_cap_side":
                RodBearingCapSideAssemblyControl(movingObject);
                break;
            case "rod_bearing_rod_side":
                RodBearingRodSideAssemblyControl(movingObject);
                break;
            case "rod_bolt_1":
                RodBolt1AssemblyControl(movingObject);
                break;
            case "rod_bolt_2":
                RodBolt2AssemblyControl(movingObject);
                break;
            case "rod_cap":
                RodCapAssemblyControl(movingObject);
                break;
            case "wrist_pin":
                WristPinAssemblyControl(movingObject);
                break;
        }

    }
    void RodAssemblyControl(GameObject rod)                                                                                          // Rod montaj için kontrol ediliyor
    {
        if (Vector3.Distance(rod.transform.position + new Vector3(0, 0.06f, 0), piston.transform.position) < 0.03f)                  // Rod objesi montaj konumu ile olan yakýnlýðý kontrol ediliyor
        {
            piston.transform.GetChild(0).gameObject.SetActive(true);                                                                  // Yakýnsa seffaf olarak montaj edilmiþ hali gösteriliyor
            data.rodAssamblyCheck = true;                                                                                            // Montaj için uygun 
        }
        else
        {
            piston.transform.GetChild(0).gameObject.SetActive(false);                                                                // Yakýn olmadýðý için seffaf obje gizleniyor
            data.rodAssamblyCheck = false;                                                                                           // Montaj için uygun deðil
            rod.transform.parent = pistonParent.transform;                                                                           // Demonte edilirse ebeveyni tekrar piston olarak deðiþtirliyor

        }


    }
    void WristPinAssemblyControl(GameObject wristPin)
    {
        if (Vector3.Distance(wristPin.transform.position , piston.transform.position + new Vector3(-0.023f, -0.01f, 0)) < 0.04f)
        {
            piston.transform.GetChild(1).gameObject.SetActive(true);
            data.wristPinAssamblyCheck = true;
        }
        else
        {
            piston.transform.GetChild(1).gameObject.SetActive(false);
            data.wristPinAssamblyCheck = false;
            rod.GetComponent<MeshCollider>().enabled = true;                                                                          // Wristpin demonte edilirse Rod objesi tekrar tutlabilir yapýlýyor
            wristPin.transform.parent = pistonParent.transform;

        }


    }
  
    void PinClip1AssemblyControl(GameObject pinClip1)
    {
        
        if (Vector3.Distance(pinClip1.transform.position, piston.transform.position + new Vector3(-0.023f, -0.01f, 0)) < 0.06f)
        {
           
            piston.transform.GetChild(2).gameObject.SetActive(true);
            data.pinClip1AssamblyCheck = true;
        }
        else
        {
            piston.transform.GetChild(2).gameObject.SetActive(false);
            data.pinClip1AssamblyCheck = false;
            wristPin.GetComponent<MeshCollider>().enabled = true;
            pinClip1.transform.parent = pistonParent.transform;

        }


    }
    void PinClip2AssemblyControl(GameObject pinClip2)
    {
        if (Vector3.Distance(pinClip2.transform.position, piston.transform.position + new Vector3(+0.023f, -0.01f, 0)) < 0.06f)
        {
           
            piston.transform.GetChild(3).gameObject.SetActive(true);
            data.pinClip2AssamblyCheck = true;
        }
        else
        {
            piston.transform.GetChild(3).gameObject.SetActive(false);
            data.pinClip2AssamblyCheck = false;
           pinClip2.transform.parent = pistonParent.transform;


        }


    }
    void RodBearingRodSideAssemblyControl(GameObject rodBearingRodSide)
    {
        if (Vector3.Distance(rodBearingRodSide.transform.position, rod.transform.position + new Vector3(0, -0.06f, 0)) < 0.03f)
        {

            rod.transform.GetChild(0).gameObject.SetActive(true);
            data.rodBearingRodSideAssamblyCheck = true;
        }
        else
        {
            rod.transform.GetChild(0).gameObject.SetActive(false);
            data.rodBearingRodSideAssamblyCheck = false;
            rodBearingRodSide.transform.parent = pistonParent.transform;
        }
           
    }
    void RodBearingCapSideAssemblyControl(GameObject rodBearingCapSide)
    {
        if (Vector3.Distance(rodBearingCapSide.transform.position, rodCap.transform.position ) < 0.03f)
        {

            rodCap.transform.GetChild(0).gameObject.SetActive(true);
            data.rodBearingCapSideAssamblyCheck = true;
        }
        else
        {
            rodCap.transform.GetChild(0).gameObject.SetActive(false);
            data.rodBearingCapSideAssamblyCheck = false;
            rodBearingCapSide.transform.parent = pistonParent.transform;
        }

    }
           
    void RodCapAssemblyControl(GameObject rodCap)
    {
        if (Vector3.Distance(rodCap.transform.position, rod.transform.position + new Vector3(0, -0.08f, 0) ) < 0.03f)
        {

            rod.transform.GetChild(1).gameObject.SetActive(true);
            data.rodCapAssamblyCheck = true;
        }
        else
        {
            rod.transform.GetChild(1).gameObject.SetActive(false);
            data.rodCapAssamblyCheck = false;
            rodCap.transform.parent = pistonParent.transform;
            rodBearingCapSide.GetComponent<MeshCollider>().enabled = true;
            rodBearingRodSide.GetComponent<MeshCollider>().enabled = true;
        }
            
    }
    void RodBolt1AssemblyControl(GameObject rodBolt1)
    {
        if (Vector3.Distance(rodBolt1.transform.position, rodCap.transform.position + new Vector3(0.022f, 0.014f, -0.022f)) < 0.03f)
        {

            rodCap.transform.GetChild(1).gameObject.SetActive(true);
            data.rodBolt1AssamblyCheck = true;
        }
        else
        {
            rodCap.transform.GetChild(1).gameObject.SetActive(false);
            data.rodBolt1AssamblyCheck = false;
            rodBolt1.transform.parent = pistonParent.transform;
        }
            
    }
    void RodBolt2AssemblyControl(GameObject rodBolt2)
    {
       
        if (Vector3.Distance(rodBolt2.transform.position, rodCap.transform.position + new Vector3(-0.022f, 0.014f, -0.022f)) < 0.05f)
        {
            
            rodCap.transform.GetChild(2).gameObject.SetActive(true);
            data.rodBolt2AssamblyCheck = true;
        }
        else
        {
            rodCap.transform.GetChild(2).gameObject.SetActive(false);
            data.rodBolt2AssamblyCheck = false;
            rodBolt2.transform.parent = pistonParent.transform;
            if (data.rodBolt1AssamblyCheck == false)
            {
                rodCap.GetComponent<MeshCollider>().enabled = true;
            }
        }
            
    }
}
