using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Animator animator;
    public Camera playerCamera;
    public GameObject[] tools;
    public GameObject[] toolsUI;

    private float speed = 10;
    private float gravity = -3f;
    public Transform groundCheck;
    Vector3 velocity;
    bool isGrounded;
    
    bool areKeysDown;
    int accelerate = 0;
    float toolNumber = 1;

    void Awake()
    {
        controller = this.GetComponent<CharacterController>();
        animator = playerCamera.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity);

        // Movement //

        if(Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
        {
            areKeysDown = true;
            animator.SetBool("IsMoving", true);
        }
        else
        {
            areKeysDown = false;
            animator.SetBool("IsMoving", false);
        }
        if (Input.GetKey("left shift") && areKeysDown == true)
        {
            if(accelerate < 20)
            {
                speed += .5f; //max speed is 30
                playerCamera.fieldOfView += 0.5f; //max fov is 80f
                accelerate += 1; //max accelerate is 100;
            }
        }
        else
        {
            if(accelerate > 0)
            {
                speed -= .5f; //min speed is 5 speeds
                playerCamera.fieldOfView -= 0.5f; //min fov is 60f
                accelerate -= 1; //min accelerate is 0;
            }
        }

        if (Input.GetKeyDown("space") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(.5f * -.5f * gravity);
        }

        //      Hands     //

        //      Tools    //

        //  MouseWheel
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) 
        {
            toolNumber += 1;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f) 
        {
            toolNumber -= 1;
        }
        //  MouseOverflow
        if(toolNumber > 3)
        {
            toolNumber = 1;
        }
        if(toolNumber < 1)
        {
            toolNumber = 3;
        }
        //  ToolSwaps
        if(toolNumber == 1)
        {
            this.tools[0].SetActive(true);
            this.toolsUI[0].SetActive(true);
            this.tools[1].SetActive(false);
            this.toolsUI[1].SetActive(false);
            this.tools[2].SetActive(false);
            this.toolsUI[2].SetActive(false);
        }
        if(toolNumber == 2)
        {
            this.tools[0].SetActive(false);
            this.toolsUI[0].SetActive(false);
            this.tools[1].SetActive(true);
            this.toolsUI[1].SetActive(true);
            this.tools[2].SetActive(false);
            this.toolsUI[2].SetActive(false);
        }
        if(toolNumber == 3)
        {
            this.tools[0].SetActive(false);
            this.toolsUI[0].SetActive(false);
            this.tools[1].SetActive(false);
            this.toolsUI[1].SetActive(false);
            this.tools[2].SetActive(true);
            this.toolsUI[2].SetActive(true);
        }
    }
}
