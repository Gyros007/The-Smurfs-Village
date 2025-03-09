using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplePie : MonoBehaviour
{
    public void PutPie()
    {
        gameObject.transform.localPosition = new Vector3((float)-9.998944, (float)2.075, (float)-2.224516);
    }

    public void eatPie()
    {
        gameObject.SetActive(false);
    }
}
