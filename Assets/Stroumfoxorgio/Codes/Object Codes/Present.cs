using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Present : MonoBehaviour
{
    private Animator anim;
    public GameObject vari;
    public Animator boomAnim;
    public bool flag=false;
    public float time;
    
    // Use this for initialization
    void Start () {

       anim = GetComponent<Animator>();

    }
    
            IEnumerator DelayTime()
    {
        //Print the time of when the function is first called.

        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(time);
    	 	 boomAnim.Play("Explosion");
    	yield return new WaitForSeconds(time);
	vari.SetActive(false);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
    

    
    public void openPresent () {

             anim.Play("Take 001"); //this
 
    	 	vari = GameObject.FindGameObjectWithTag("Boom");
    	 	boomAnim = vari.GetComponent<Animator>();
    	 	time = 0.70f;
    	 	StartCoroutine(DelayTime());

		//var clip = animController.animationClips.First(a => a.name == "[Explosion]");
		//Debug.Log(animation[Explosion].length);
		//vari.SetActive(false);

        
    }
}
