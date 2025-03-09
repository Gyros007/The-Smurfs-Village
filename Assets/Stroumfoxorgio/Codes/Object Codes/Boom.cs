using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{


    public Animator boomAnim;
    //public Variables var;
    // Start is called before the first frame update
    void Start()
    {
         boomAnim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
       

	// if (true)
      //{
        //if(pres)
       // {
           //boomAnim.Play("Explosion");
       //}
    }
    
    public void openExplosion(){
     boomAnim.Play("Explosion");
    
    }
}
