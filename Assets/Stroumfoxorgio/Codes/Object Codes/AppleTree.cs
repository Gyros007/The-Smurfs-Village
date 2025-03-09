using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    public GameObject Apple1;
    public GameObject Apple2;
    public GameObject Apple3;


    public void shakeTree()
    {
        Apple1.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        Apple2.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        Apple3.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }
    

}
