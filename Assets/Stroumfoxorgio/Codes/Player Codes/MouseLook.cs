using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VIDE_Data;


public class MouseLook : MonoBehaviour
{

   public bool flag = false;
    public float mouseSensitivity;
	public Transform playerBody;
    public Variables var;

    float xRotation = 0f;
	Camera cam;
    Text messageText;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
		cam = Camera.main;
        messageText = GameObject.Find("Canvas/Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!VD.isActive)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
            //float mouseX = 0f;
            //float mouseY = 0f;
            //if (Input.GetKey(KeyCode.UpArrow))
            //{
            //    mouseY = 100f;
            //}
            //if (Input.GetKey(KeyCode.DownArrow))
            //{
            //    mouseY = -100f;
            //}
            //if (Input.GetKey(KeyCode.LeftArrow))
            //{
            //    mouseX = -100f;
            //}
            //if (Input.GetKey(KeyCode.RightArrow))
            //{
            //    mouseX = 100f;
            //}

            xRotation -= mouseY * Time.deltaTime;
			xRotation = Mathf.Clamp(xRotation, -90f, 90f);

			transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
			playerBody.Rotate(Vector3.up * mouseX * Time.deltaTime);
		}
		
		float distance = 5f;
		RaycastHit hit;
        messageText.text = "";




        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, distance))
            if (hit.collider.CompareTag("NPC") && !VD.isActive)
            {
                messageText.color = new Color(136.0f / 255.0f, 204.0f / 255.0f, 255.0f / 255.0f);
                messageText.text = "Press F to talk with " + hit.collider.name;
            }
            else if (hit.collider.CompareTag("Object") && !VD.isActive)
            {
                messageText.color = new Color(136.0f / 255.0f, 204.0f / 255.0f, 255.0f / 255.0f);
                switch (hit.collider.name)
                {
                    case "MyDoor":
                        if (hit.collider.GetComponent<Animator>().GetBool("IsOpen"))
                            messageText.text = "Press F to close the door";
                        else
                            messageText.text = "Press F to open the door";
                        if (Input.GetKeyDown(KeyCode.F))
                        {
                            if (hit.collider.GetComponent<Animator>().GetBool("IsOpen"))
                                hit.collider.GetComponent<Door>().closeDoor();
                            else
                                hit.collider.GetComponent<Door>().openDoor();
                        }
                        break;

                    case "Door":
                        if (var.isDay)
                        {
                            if (hit.collider.GetComponent<Animator>().GetBool("IsOpen"))
                                messageText.text = "Press F to close the door";
                            else
                                messageText.text = "Press F to open the door";

                            if (Input.GetKeyDown(KeyCode.F))
                            {
                                if (hit.collider.GetComponent<Animator>().GetBool("IsOpen"))
                                    hit.collider.GetComponent<Door>().closeDoor();
                                else
                                    hit.collider.GetComponent<Door>().openDoor();
                            }
                        }
                        break;

                    case "Present":
                        //Animator anim;
                        //anim = GetComponent<Animator>();
                        //if (hit.collider.GetComponent<Animator>()) //.GetBool("IsUnopened")

                        if (!flag)
                        {
                            messageText.text = "Press F to open the present";
                            if (Input.GetKeyDown(KeyCode.F))
                            {
                                flag = true;

                                var.openPresent = true;
                                //if (hit.collider.GetComponent<Animator>().GetBool("IsUnopened")){
                                hit.collider.GetComponent<Present>().openPresent();
                                //}
                                //anim.Play("Take 001");
                                //hit.collider.GetComponent<Present>().openPresent();
                                //hit.collider.GetComponent<Animator>()
                            }
                        }
                        break;



                    case "Bed":
                        messageText.text = "Press F to sleep";
                        if (Input.GetKeyDown(KeyCode.F))
                        {
                            Bed bedFunction = hit.collider.gameObject.GetComponent<Bed>();
                            bedFunction.Sleep();
                        }
                        break;

                    case "AppleTree":
                        messageText.text = "Press F to kick the tree";
                        if (Input.GetKeyDown(KeyCode.F))
                        {
                            hit.collider.tag = "Untagged";
                            AppleTree treeFunction = hit.collider.gameObject.GetComponent<AppleTree>();
                            treeFunction.shakeTree();
                        }
                        break;

                    case "ApplePie":
                        messageText.text = "Press F to eat the apple pie";
                        if (Input.GetKeyDown(KeyCode.F)) ;

                        break;

                    default:
                        messageText.text = "Press F to pick up";
                        break;
                }
            }
            else if (hit.collider.CompareTag("Invisible Wall") && !VD.isActive)
            {
                messageText.text = "WARNING: DANGEROUS AREA AHEAD!";
                messageText.color = Color.red;
            }

    }
}
