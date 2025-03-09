using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintBrush : MonoBehaviour
{
    public void CollectPaintBrush()
    {
        gameObject.tag = "Untagged";
        gameObject.transform.localPosition = new Vector3((float)30.9200001, (float)-6.6400001, (float)-20.8560009);
    }

    public void putBrushInPaint()
    {
        gameObject.transform.localRotation = new Quaternion((float)-0.874021471, (float)-0.123019472, (float)-0.334349632, (float)0.330398262);
        gameObject.transform.position = new Vector3((float)-8.96273041, (float)1.23317599, (float)412.538147);
    }
}
