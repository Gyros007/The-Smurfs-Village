using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour
{
    public Variables var;
    public Light light;

    public void BuildBed()
    {
        gameObject.transform.localPosition = new Vector3((float)-5.67000008, (float)2.00999999, (float)-2.88599992);
    }

    public void Sleep()
    {
       if (var.isDay)
        {
            Material nightMat = (Material)Resources.Load("Skies/Materials/FS002/FS002_Night", typeof(Material));
            RenderSettings.skybox = nightMat;
            var.isDay = false;
            foreach (var gameObj in FindObjectsOfType(typeof(Door)) as Door[])
            {
                if (gameObj.name == "Door")
                {
                    gameObj.closeDoor();
                }
            }

            GameObject smurfs = GameObject.Find("Smurfs");
            smurfs.transform.localPosition = new Vector3((float)-29.96073, (float)-5.0, (float)410.6682);

            GameObject fire = GameObject.Find("TinyFire");
            fire.transform.localPosition = new Vector3((float)0.05, (float)-15.0, (float)-0.1443052);

            GameObject invisibleWalls = GameObject.Find("InvisibleWallsDrakoumel");
            invisibleWalls.transform.localPosition = new Vector3((float)-5.08203173, (float)-204.899994, (float)0.195617199);

            light.intensity = 0.2f;

            DynamicGI.UpdateEnvironment();


        }
        else
        {
            Material dayMat = (Material)Resources.Load("Skies/Materials/FS002/FS002_Day_Sunless", typeof(Material));
            RenderSettings.skybox = dayMat;
            var.isDay = true;
            GameObject smurfs = GameObject.Find("Smurfs");
            smurfs.transform.localPosition = new Vector3((float)-29.96073, (float)3.895176, (float)410.6682);

            GameObject fire = GameObject.Find("TinyFire");
            fire.transform.localPosition = new Vector3((float)0.05, (float)1.83, (float)-0.1443052);

            GameObject invisibleWalls = GameObject.Find("InvisibleWallsDrakoumel");
            invisibleWalls.transform.localPosition = new Vector3((float)-5.08203173, (float)43.26972, (float)0.195617199);

            light.intensity = 0.8f;

            DynamicGI.UpdateEnvironment();
        }
    }
}
