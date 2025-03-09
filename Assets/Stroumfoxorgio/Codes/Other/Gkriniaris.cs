using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gkriniaris : MonoBehaviour

{

    public Transform parent;

    public void GoBackToSmurfVillage()
    {
        gameObject.transform.SetParent(parent, false);
        gameObject.transform.localPosition = new Vector3((float)64.95, (float)-1.87, (float)-54.6300011);
        gameObject.transform.localRotation = new Quaternion((float)0.69080162, (float)-0.150974542, (float)0.150974214, (float)0.690801501);
        gameObject.transform.localScale = new Vector3((float)0.0111755934, (float)0.025698116, (float)0.0256981086);
    }
}
