using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VIDE_Data;
using UnityEngine.SceneManagement;


public class VIDEDemoPlayer : MonoBehaviour
{
    //This script handles player movement and interaction with other NPC game objects

    public string playerName = "You";

    //Reference to our diagUI script for quick access
    public VIDEUIManager1 diagUI;
    public QuestChartDemo questUI;

    //Stored current VA when inside a trigger
    public VIDE_Assign inTrigger;

    //DEMO variables for item inventory
    //Crazy cap NPC in the demo has items you can collect
    public List<string> demo_Items = new List<string>();
    public List<string> demo_ItemInventory = new List<string>();

    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private bool pressedOnce;


    Vector3 velocity;
    bool isGrounded;

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<VIDE_Assign>() != null)
            inTrigger = other.GetComponent<VIDE_Assign>();
    }

    void OnTriggerExit()
    {
        inTrigger = null;
    }

    void Start()
    {
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        if (!isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }

        controller.Move(velocity * Time.deltaTime);

        //Only allow player to move and turn if there are no dialogs loaded
        if (!VD.isActive)
        {

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            if (Input.GetButtonDown("Shift"))
            {
                speed = 24f;
            }
            else if (Input.GetButtonUp("Shift"))
            {
                speed = 12f;
            }
        }

        //Interact with NPCs when pressing F
        if (Input.GetKeyDown(KeyCode.F))
        {
            TryInteract();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (!VD.isActive)
            {
                pressedOnce = true;
                questUI.Interact();
            }
            else if (VD.isActive && pressedOnce)
            {
                pressedOnce = false;
                questUI.Interact();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        //Hide/Show cursor
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.visible = !Cursor.visible;
            if (Cursor.visible)
                Cursor.lockState = CursorLockMode.None;
            else
                Cursor.lockState = CursorLockMode.Locked;
        }
    }

    //Casts a ray to see if we hit an NPC and, if so, we interact
    void TryInteract()
    {
        /* Prioritize triggers */

        if (inTrigger)
        {
            diagUI.Interact(inTrigger);
            return;
        }

        /* If we are not in a trigger, try with raycasts */

        RaycastHit rHit;

        if (Physics.Raycast(transform.position, transform.forward, out rHit, 5f))
        {
            //Lets grab the NPC's VIDE_Assign script, if there's any
            VIDE_Assign assigned;
            if (rHit.collider.GetComponent<VIDE_Assign>() != null)
                assigned = rHit.collider.GetComponent<VIDE_Assign>();
            else return;
            diagUI.Interact(assigned); //Begins interaction
        }
    }
}
