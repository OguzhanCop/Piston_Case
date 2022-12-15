using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PistonAssembly : MonoBehaviour
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

    public Data data;
    

    private void OnEnable()
    {
        EventManager.assemblyObject += AssemblyObject;
    }
    private void OnDisable()
    {
        EventManager.assemblyObject -= AssemblyObject;
    }
   


    void AssemblyObject(GameObject assemblyObject)                                      // Býrakýlan objenin bilgisi dýþarýdan gelýyor ve buna göre ilgili fonksiyonu çalýþtýrýyoruz
    {
        switch (assemblyObject.name)
        {

            case "pin_clip_1":
                PinClip1Assembly(assemblyObject);
                break;
            case "pin_clip_2":
                PinClip2Assembly(assemblyObject);
                break;
            case "piston":
                
                break;
            case "rod":
                RodAssembly(assemblyObject);
                break;
            case "rod_bearing_cap_side":
                RodBearingCapSideAssembly(assemblyObject);
                break;
            case "rod_bearing_rod_side":
                RodBearingRodSideAssembly(assemblyObject);
                break;
            case "rod_bolt_1":
                RodBolt1Assembly(assemblyObject);
                break;
            case "rod_bolt_2":
                RodBolt2Assembly(assemblyObject);
                break;
            case "rod_cap":
                RodCapAssembly(assemblyObject);
                break;
            case "wrist_pin":
                WristPinAssembly(assemblyObject);
                break;
        }
    }
    void RodAssembly(GameObject rod)                                                                                                    // Rod Montaj Fonksiyonu
    {
        if (data.rodAssamblyCheck == true)                                                                                              // Montaj yapýlacak objenin konumu bool kontrolü 
        {
            data.assemblyActive = true;                                                                                                 // Montaj iþlemi baþladý
            rod.transform.DOMove(piston.transform.GetChild(0).position + new Vector3(0, -0.04f, 0), 1.5f, false).OnComplete(() =>       // Objenin montaj animasyonu 
                rod.transform.DOMove(piston.transform.GetChild(0).position, 1.5f, false));

            StartCoroutine(AssemblyFinish());                                                                                           // Montaj bitirmek için gecikme baþlatýlýyor
            rod.transform.parent = piston.transform;                                                                                    // Objeyi çocuk obje yapyoruz
            piston.transform.GetChild(0).gameObject.SetActive(false);                                                                   // Þeffaf objeyi gizliyoruz               
            EventManager.successfulPanel.Invoke();                                                                                      // Tebrikler mesajýný içeren event çalýþtýrýlýyor
        } 


    }
    void WristPinAssembly(GameObject wristPin)
    {
        if (data.wristPinAssamblyCheck == true && data.rodAssamblyCheck == true)                                                        // Montaj yapýlacak obje ve kendisinden önce montaj yapýlmýþ olmasý gereken obje kontrolü
        {
            data.assemblyActive = true;
            wristPin.transform.DOMove(piston.transform.GetChild(1).position + new Vector3(-0.08f, 0, -0.08f), 1.5f, false).OnComplete(() =>
               wristPin.transform.DOMove(piston.transform.GetChild(1).position, 1.5f, false));

            StartCoroutine(AssemblyFinish());
            wristPin.transform.parent = piston.transform;
            piston.transform.GetChild(1).gameObject.SetActive(false);
            rod.GetComponent<MeshCollider>().enabled=false;                                                                             // Wrist pin takýlýyken rod objesinin demonte edilememsi gerekiyor objenin tutulmaasý engellenýyor
            EventManager.successfulPanel.Invoke();

        }


    }

    void PinClip1Assembly(GameObject pinClip1)
    {
        if (data.wristPinAssamblyCheck == true && data.rodAssamblyCheck == true && data.pinClip1AssamblyCheck == true)
        {
            data.assemblyActive = true;
            pinClip1.transform.DOMove(piston.transform.GetChild(2).position + new Vector3(-0.04f, 0, -0.04f), 1.5f, false).OnComplete(() =>
               pinClip1.transform.DOMove(piston.transform.GetChild(2).position, 1.5f, false));

            StartCoroutine(AssemblyFinish());
            pinClip1.transform.parent = piston.transform;
            piston.transform.GetChild(2).gameObject.SetActive(false);
            wristPin.GetComponent<MeshCollider>().enabled = false;
            EventManager.successfulPanel.Invoke();
        }



    }
    void PinClip2Assembly(GameObject pinClip2)
    {
        if (data.wristPinAssamblyCheck == true && data.rodAssamblyCheck == true && data.pinClip2AssamblyCheck == true)
        {
            data.assemblyActive = true;
            pinClip2.transform.DOMove(piston.transform.GetChild(3).position + new Vector3(0.04f, 0, 0.04f), 1.5f, false).OnComplete(() =>
                 pinClip2.transform.DOMove(piston.transform.GetChild(3).position, 1.5f, false));

            StartCoroutine(AssemblyFinish());
            pinClip2.transform.parent = piston.transform;
            piston.transform.GetChild(3).gameObject.SetActive(false);
            EventManager.successfulPanel.Invoke();
        }
    }



    void RodBearingRodSideAssembly(GameObject rodBearingRodSide)
    {
        if (data.rodBearingRodSideAssamblyCheck == true && data.rodCapAssamblyCheck == false)                                                // Montaj yapýlacak obje ve kendisinden önce yapýlmamasý gereken montaj kontrolü
        {
            data.assemblyActive = true;
            rodBearingRodSide.transform.DOMove(rod.transform.GetChild(0).position + new Vector3(0, -0.04f, 0), 1.5f, false).OnComplete(() =>
               rodBearingRodSide.transform.DOMove(rod.transform.GetChild(0).position, 1.5f, false));

            StartCoroutine(AssemblyFinish());
            rodBearingRodSide.transform.parent = rod.transform;
            rod.transform.GetChild(0).gameObject.SetActive(false);
            EventManager.successfulPanel.Invoke();
        }

    }

    void RodBearingCapSideAssembly(GameObject rodBearingCapSide)
    {
        if (data.rodBearingCapSideAssamblyCheck == true && data.rodCapAssamblyCheck==false)
        {
            data.assemblyActive = true;
            rodBearingCapSide.transform.DOMove(rodCap.transform.GetChild(0).position + new Vector3(0, 0.04f, 0), 1.5f, false).OnComplete(() =>
               rodBearingCapSide.transform.DOMove(rodCap.transform.GetChild(0).position, 1.5f, false));

            StartCoroutine(AssemblyFinish());
            rodBearingCapSide.transform.parent = rodCap.transform;
            rodCap.transform.GetChild(0).gameObject.SetActive(false);
            EventManager.successfulPanel.Invoke();
        }

    }

    void RodCapAssembly(GameObject rodCap)
    {
        if (data.rodCapAssamblyCheck== true && data.rodBearingCapSideAssamblyCheck==true && data.rodBearingRodSideAssamblyCheck==true )
        {
            data.assemblyActive = true;
            rodCap.transform.DOMove(rod.transform.GetChild(1).position + new Vector3(0, -0.04f, 0), 1.5f, false).OnComplete(() =>
               rodCap.transform.DOMove(rod.transform.GetChild(1).position, 1.5f, false));

            StartCoroutine(AssemblyFinish());
            rodCap.transform.parent = rod.transform;
            rod.transform.GetChild(1).gameObject.SetActive(false);
            rodBearingCapSide.GetComponent<MeshCollider>().enabled = false;
            rodBearingRodSide.GetComponent<MeshCollider>().enabled = false;
            EventManager.successfulPanel.Invoke();
        }

    }
    void RodBolt1Assembly(GameObject rodBolt1)
    {
        if (data.rodBolt1AssamblyCheck == true && data.rodCapAssamblyCheck==true)
        {
            data.assemblyActive = true;
            Sequence rodBolt1Sequence = DOTween.Sequence();
            rodBolt1Sequence.Append(rodBolt1.transform.DOMove(rodCap.transform.GetChild(1).position + new Vector3(0, -0.04f, 0), 1.5f, false));
            rodBolt1Sequence.Append(rodBolt1.transform.DOMove(rodCap.transform.GetChild(1).position, 1.5f, false));
            rodBolt1Sequence.Join(rodBolt1.transform.DORotate(new Vector3(0,360,0),0.15f,RotateMode.FastBeyond360).SetRelative(true).SetLoops(10).SetEase(Ease.Linear));

            StartCoroutine(AssemblyFinish());
            rodBolt1.transform.parent = rodCap.transform;
            rodCap.transform.GetChild(1).gameObject.SetActive(false);
            rodCap.GetComponent<MeshCollider>().enabled = false;
            EventManager.successfulPanel.Invoke();
        }

    }
    void RodBolt2Assembly(GameObject rodBolt2)
    {
        if (data.rodBolt2AssamblyCheck == true && data.rodCapAssamblyCheck == true)
        {
            data.assemblyActive = true;
            Sequence rodBolt2Sequence = DOTween.Sequence();
            rodBolt2Sequence.Append(rodBolt2.transform.DOMove(rodCap.transform.GetChild(2).position + new Vector3(0, -0.04f, 0), 1.5f, false));
            rodBolt2Sequence.Append(rodBolt2.transform.DOMove(rodCap.transform.GetChild(2).position, 1.5f, false));
            rodBolt2Sequence.Join(rodBolt2.transform.DORotate(new Vector3(0, 360, 0), 0.15f, RotateMode.FastBeyond360).SetRelative(true).SetLoops(10).SetEase(Ease.Linear));

            StartCoroutine(AssemblyFinish());
            rodBolt2.transform.parent = rodCap.transform;
            rodCap.transform.GetChild(2).gameObject.SetActive(false);
            rodCap.GetComponent<MeshCollider>().enabled = false;
            EventManager.successfulPanel.Invoke();
        }

    }
    IEnumerator AssemblyFinish()                                                        // Montaj animasyonlarý bittikten sonra bool ile montaj aktifliði deðiþtirliyor
    {
        yield return new WaitForSecondsRealtime(3.2f);
        data.assemblyActive = false;

    }    
    

}

