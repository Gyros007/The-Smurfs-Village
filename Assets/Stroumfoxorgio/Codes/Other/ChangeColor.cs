using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    // Start is called before the first frame update
    public void redColor()
    {
        Material newMat = (Material)Resources.Load("Material/Top hue=350", typeof(Material));
        gameObject.GetComponent<Renderer>().material = newMat;
    }

    public void orangeColor()
    {
        Material newMat = (Material)Resources.Load("Material/Top hue=10", typeof(Material));
        gameObject.GetComponent<Renderer>().material = newMat;
    }

    public void yellowColor()
    {
        Material newMat = (Material)Resources.Load("Material/Top hue=50", typeof(Material));
        gameObject.GetComponent<Renderer>().material = newMat;
    }

    public void greenColor()
    {
        Material newMat = (Material)Resources.Load("Material/Top hue=120", typeof(Material));
        gameObject.GetComponent<Renderer>().material = newMat;
    }

    public void cyanColor()
    {
        Material newMat = (Material)Resources.Load("Material/Top hue=180", typeof(Material));
        gameObject.GetComponent<Renderer>().material = newMat;
    }

    public void blueColor()
    {
        Material newMat = (Material)Resources.Load("Material/Top hue=220", typeof(Material));
        gameObject.GetComponent<Renderer>().material = newMat;
    }

    public void purpleColor()
    {
        Material newMat = (Material)Resources.Load("Material/Top hue=260", typeof(Material));
        gameObject.GetComponent<Renderer>().material = newMat;
    }

    public void pinkColor()
    {
        Material newMat = (Material)Resources.Load("Material/Top hue=330", typeof(Material));
        gameObject.GetComponent<Renderer>().material = newMat;
    }
}
