using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : BatteryPowered
{
    private CharacterController controller;
    private float speed, chargedSpeed, gravity, jumpSpeed;
    private Vector2 inputMovement, lookRotation;
    private Vector3 playerMovement, startingPos;
    private bool carryingBattery, dead, respawned;
    private GameObject interacableObject;
    public GameObject manager;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("TargetGroup").GetComponent<CinemachineTargetGroup>().AddMember(this.transform, 1, 5.0f);
        speed = 0.10f;
        chargedSpeed = 0.25f;
        gravity = 0.10f;
        jumpSpeed = 1f;
        controller = GetComponent<CharacterController>();
        carryingBattery = dead = false;
        battery = FindBattery();
        startingPos = transform.position;
        manager = GameObject.FindGameObjectWithTag("GameController");
        manager.GetComponent<Manager>().AddPlayer(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfCharged(this.transform.position);
    }

    private void FixedUpdate()
    {
        if (!dead)
        {
            Move();
            Rotate();
        }
        if(respawned)
        {
            dead = false;
            respawned = false;
        }
    }

    private void Move()
    {
        if (isCharged)
        {
            playerMovement.x = inputMovement.x * chargedSpeed;
            playerMovement.y -= gravity;
            playerMovement.z = inputMovement.y * chargedSpeed;
        }
        else
        {
            playerMovement.x = inputMovement.x * speed;
            playerMovement.y -= gravity;
            playerMovement.z = inputMovement.y * speed;
        }
        controller.Move(playerMovement);

        if (inputMovement.x != 0 || inputMovement.y != 0)
        {
            float lookAngle = Mathf.Atan2(inputMovement.x, inputMovement.y) * (180 / Mathf.PI);
            Vector3 lookDirection = new Vector3(0.0f, lookAngle, 0.0f);
            transform.rotation = Quaternion.Euler(lookDirection);
        }

    }
    private void Rotate()
    {
        if (lookRotation.x != 0 || lookRotation.y != 0)
        {
            float lookAngle = Mathf.Atan2(lookRotation.x, lookRotation.y) * (180 / Mathf.PI);
            Vector3 lookDirection = new Vector3(0.0f, lookAngle, 0.0f);
            transform.rotation = Quaternion.Euler(lookDirection);
        }
    }
    private void OnMove(InputValue value)
    {
        inputMovement = value.Get<Vector2>();
    }

    private void OnAim(InputValue value)
    {
        lookRotation = value.Get<Vector2>();

    }

    private void OnInteract()
    {
        if (interacableObject != null)
        {
            if (interacableObject == battery)
            {
                battery.GetComponent<BatteryScript>().PickUp(this.gameObject);
                carryingBattery = true;
            }
            else if(interacableObject.GetComponent<BatteryPowered>().isCharged == true)
            {
                interacableObject.GetComponent<BatteryPowered>().Interact();
            }
        }
    }

    private void OnJump()
    {
        if(controller.isGrounded && isCharged)
        {
            playerMovement.y = jumpSpeed;
        }
    }

    private void OnThrow()
    {
        if(carryingBattery)
        {
            battery.GetComponent<BatteryScript>().Thrown(this.gameObject);
            carryingBattery = false;
        }
    }

    private void OnDrop()
    {
        if(carryingBattery)
        {
            battery.GetComponent<BatteryScript>().Dropped();
            carryingBattery = false;
        }
    }

    public void Death()
    {
        transform.position = startingPos;
        carryingBattery = false;
        respawned = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        interacableObject = other.gameObject;
        if (other.tag == "Enemy")
        {
            dead = true;
            manager.GetComponent<Manager>().PlayerDied(battery);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        interacableObject = null;
    }
}
