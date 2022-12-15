using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistonAssemblyIndicator : MonoBehaviour
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


    void SelectMovingObject(GameObject movingObject)
    {
        switch (movingObject.name)
        {
            
            case "pin_clip_1":
                PinClip1Assembly(movingObject);
                break;
            case "pin_clip_2":
                PinClip2Assembly(movingObject);
                break;
            case "piston":
                Debug.Log("4");
                break;
            case "rod":
                RodAssembly(movingObject);
                break;
            case "rod_bearing_cap_side":
                RodBearingCapSideAssembly(movingObject);
                break;
            case "rod_bearing_rod_side":
                RodBearingRodSideAssembly(movingObject);
                break;
            case "rod_bolt_1":
                RodBolt1Assembly(movingObject);
                break;
            case "rod_bolt_2":
                RodBolt2Assembly(movingObject);
                break;
            case "rod_cap":
                RodCapAssembly(movingObject);
                break;
            case "wrist_pin":
                WristPinAssembly(movingObject);
                break;
        }

    }
    void RodAssembly(GameObject rod)
    {
        if (Vector3.Distance(rod.transform.position + new Vector3(0, 0.06f, 0), piston.transform.position) < 0.03f)
        {
            piston.transform.GetChild(0).gameObject.SetActive(true);
            data.rodAssamblyCheck = true;
        }
        else
        {
            piston.transform.GetChild(0).gameObject.SetActive(false);
            data.rodAssamblyCheck = false;
            rod.transform.parent = pistonParent.transform;

        }


    }
    void WristPinAssembly(GameObject wristPin)
    {
        if (Vector3.Distance(wristPin.transform.position , piston.transform.position) < 0.03f)
        {
            piston.transform.GetChild(1).gameObject.SetActive(true);
            data.wristPinAssamblyCheck = true;
        }
        else
        {
            piston.transform.GetChild(1).gameObject.SetActive(false);
            data.wristPinAssamblyCheck = false;
            rod.GetComponent<MeshCollider>().enabled = true;
            wristPin.transform.parent = pistonParent.transform;

        }


    }
  
    void PinClip1Assembly(GameObject pinClip1)
    {
        Debug.Log(Vector3.Distance(pinClip1.transform.position, piston.transform.position + new Vector3(-0.023f, -0.01f, 0)));
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
    void PinClip2Assembly(GameObject pinClip2)
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
    void RodBearingRodSideAssembly(GameObject rodBearingRodSide)
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
    void RodBearingCapSideAssembly(GameObject rodBearingCapSide)
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
           
    void RodCapAssembly(GameObject rodCap)
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
    void RodBolt1Assembly(GameObject rodBolt1)
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
    void RodBolt2Assembly(GameObject rodBolt2)
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
