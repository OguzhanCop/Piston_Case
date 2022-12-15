using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data")]
public class Data : ScriptableObject
{
 
   
    public bool pinClip1AssamblyCheck;
    public bool pinClip2AssamblyCheck;
    public bool rodAssamblyCheck;
    public bool rodBearingCapSideAssamblyCheck;
    public bool rodBearingRodSideAssamblyCheck;
    public bool rodBolt1AssamblyCheck;
    public bool rodBolt2AssamblyCheck;
    public bool rodCapAssamblyCheck;
    public bool wristPinAssamblyCheck;

    public bool assemblyActive;
    private void OnEnable()
    {

        pinClip1AssamblyCheck=false;
        pinClip2AssamblyCheck=false;
        rodAssamblyCheck=false;
        rodBearingCapSideAssamblyCheck=false;
        rodBearingRodSideAssamblyCheck=false;
        rodBolt1AssamblyCheck=false;
        rodBolt2AssamblyCheck=false;
        rodCapAssamblyCheck=false;
        wristPinAssamblyCheck=false;
        assemblyActive=false;
}

}
