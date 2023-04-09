using System;
using UnityEngine;

public class CharacterControllerSC : MonoBehaviour
{
    public float moveSpeed = 6.0f;      // Movement speed of the character
   
    public float jumpSpeed = 8.0f;      // Jump height of the character
   
    public float gravity = 20.0f;       // Gravity force
  
    public float lowJumpMultiplier = 2.0f;   // Multiplier for low jumps

    private bool isJumping = false;      // Flag to track if the character is jumping
   
    private float currentJumpSpeed;      // Variable to store the current jump speed of the character
  
    private float verticalVelocity;      // Vertical velocity of the character

    private CharacterController controller;      // Reference to the character controller component

    void Start () 
    {
        controller = GetComponent<CharacterController>();      // Get the character controller component on Start()
    }

    void Update () 
    {
        if (controller.isGrounded) 
        {   
            // If the character is on the ground
            verticalVelocity = 0;   // Reset the vertical velocity
            if (Input.GetButtonDown("Jump")) 
            {   // If the jump button is pressed
                isJumping = true;   // Set the jumping flag
                currentJumpSpeed = jumpSpeed;   // Set the current jump speed
            }
        } 
       
        else 
        {   // If the character is in the air
            if (Input.GetButtonUp("Jump")) 
            {   
                // If the jump button is released
                isJumping = false;   // Reset the jumping flag
               
                if (verticalVelocity > 0) 
                {   // If the character is moving upwards
                    verticalVelocity = verticalVelocity / lowJumpMultiplier;   // Apply low jump multiplier
                }
            }
        }
        
        if (isJumping) 
        {   // If the character is jumping
            verticalVelocity = currentJumpSpeed;   // Set the vertical velocity to the current jump speed
            currentJumpSpeed -= gravity * Time.deltaTime;   // Decrease the current jump speed based on gravity
            if (currentJumpSpeed < 0) 
            {   // If the character is falling
                isJumping = false;   // Reset the jumping flag
            }
        } 
        
        else 
        {   // If the character is not jumping
            verticalVelocity -= gravity * Time.deltaTime;   // Apply gravity to the vertical velocity
        }
        
        controller.Move(new Vector3(Input.GetAxis("Horizontal"), verticalVelocity, 0) * moveSpeed * Time.deltaTime);   // Move the character
    }
}
