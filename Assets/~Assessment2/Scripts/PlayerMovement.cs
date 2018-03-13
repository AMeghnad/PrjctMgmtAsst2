using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float PlayerHealth = 100;
    public Vector3 movDir;
    private float SpeedAmount;
    public float Speed = 6;
    public float SprintSpeed = 9;
    public float JumpSpeed = 8;
    public float Gravity = 20;
    public CharacterController controller;
    public Transform Forward_Transform;
    public Transform Forward_Left_Transform;
    public Transform Forward_Right_Transform;
    public Transform Back_Transform;
    public Transform Back_Left_Transform;
    public Transform Back_Right_Transform;
    public Transform Left_Transform;
    public Transform Right_Transform;
    public bool Moving;
    public Vector3 OriginalPosition;
    public Animator Player_Model;
    public bool GroundStarted;
    public bool PlayerDead;
    // Use this for initialization
    void Start () {
        OriginalPosition = gameObject.GetComponent<Transform>().position;
        controller = gameObject.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetAxis("Vertical") > 0 || Input.GetAxis("Vertical") < 0)
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                if (Input.GetAxis("Horizontal") > 0)
                {
                    gameObject.GetComponent<Transform>().rotation = Quaternion.RotateTowards(gameObject.GetComponent<Transform>().rotation, Forward_Right_Transform.rotation, Time.deltaTime * 300);
                }
                else
                {
                    if (Input.GetAxis("Horizontal") < 0)
                    {
                        gameObject.GetComponent<Transform>().rotation = Quaternion.RotateTowards(gameObject.GetComponent<Transform>().rotation, Forward_Left_Transform.rotation, Time.deltaTime * 300);
                    }
                    else
                    {
                        gameObject.GetComponent<Transform>().rotation = Quaternion.RotateTowards(gameObject.GetComponent<Transform>().rotation, Forward_Transform.rotation, Time.deltaTime * 300);
                    }
                }
            }

            if (Input.GetAxis("Vertical") < 0)
            {
                if (Input.GetAxis("Horizontal") > 0)
                {
                    gameObject.GetComponent<Transform>().rotation = Quaternion.RotateTowards(gameObject.GetComponent<Transform>().rotation, Back_Right_Transform.rotation, Time.deltaTime * 300);
                }
                else
                {
                    if (Input.GetAxis("Horizontal") < 0)
                    {
                        gameObject.GetComponent<Transform>().rotation = Quaternion.RotateTowards(gameObject.GetComponent<Transform>().rotation, Back_Left_Transform.rotation, Time.deltaTime * 300);
                    }
                    else
                    {
                        gameObject.GetComponent<Transform>().rotation = Quaternion.RotateTowards(gameObject.GetComponent<Transform>().rotation, Back_Transform.rotation, Time.deltaTime * 300);
                    }
                }
            }
        }
        else
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                gameObject.GetComponent<Transform>().rotation = Quaternion.RotateTowards(gameObject.GetComponent<Transform>().rotation, Right_Transform.rotation, Time.deltaTime * 300);
            }

            if (Input.GetAxis("Horizontal") < 0)
            {
                gameObject.GetComponent<Transform>().rotation = Quaternion.RotateTowards(gameObject.GetComponent<Transform>().rotation, Left_Transform.rotation, Time.deltaTime * 300);
            }
        }
    }


	void Update ()
    {
        if(PlayerHealth <= 0)
        {
            PlayerHealth = 0;
            gameObject.GetComponent<PlayerMovement>().enabled = false;
        }

        if (Input.GetKeyDown("f"))
        {
            gameObject.GetComponent<Collider>().enabled = false;
            gameObject.GetComponent<Renderer>().enabled = true;
            Player_Model.enabled = false;
            PlayerHealth = 0;
        }

        if(gameObject.GetComponent<Transform>().position == OriginalPosition)
        {
            Moving = false;
        }
        else
        {
            Moving = true;
            OriginalPosition = gameObject.GetComponent<Transform>().position;
        }

        if(Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0 || Input.GetAxis("Vertical") > 0 || Input.GetAxis("Vertical") < 0)
        {
            if (Input.GetButton("Sprint"))
            {
                SpeedAmount = SprintSpeed;
                Player_Model.SetBool("Sprint", true);
            }
            else
            {
                SpeedAmount = Speed;
                Player_Model.SetBool("Sprint", false);
            }
            Player_Model.SetBool("Run", true);
        }
        else
        {
            Player_Model.SetBool("Sprint", false);
            Player_Model.SetBool("Run", false);
            SpeedAmount = 0;
        }

        if (controller.isGrounded == true)
        {
            GroundStarted = true;
            Player_Model.SetBool("Air", false);
            movDir = new Vector3(0, 0, SpeedAmount);
            movDir = gameObject.GetComponent<Transform>().TransformDirection(movDir);

            if (Input.GetButtonDown("Jump"))
            {
                movDir.y = JumpSpeed;
            }
        }
        else
        {
            if (GroundStarted == true)
            {
                Player_Model.SetBool("Air", true);
            }
        }
        movDir.y -= Gravity * Time.deltaTime;
        controller.Move(movDir * Time.deltaTime);
	}
}
