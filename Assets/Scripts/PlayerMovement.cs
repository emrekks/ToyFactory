<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
using System.Collections;
>>>>>>> parent of ef2ec1c (Update)
=======
using System.Collections;
>>>>>>> parent of ef2ec1c (Update)
=======
using System;
using Unity.VisualScripting;
>>>>>>> parent of 42211ae (Adding Climbing 90Degrees Wall)
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
    [Header("Movement Settings")]
    [SerializeField, Tooltip("Movement speed of the character")]
    private float moveSpeed = 6.0f;
    [Header("Movement Settings")] [SerializeField]
    private float moveSpeed = 6f;

    [SerializeField, Tooltip("Jump height of the character")]
    private float jumpSpeed = 8.0f;
=======
    [Header("Movement Settings")] [SerializeField]
    private float moveSpeed = 6f;

>>>>>>> parent of ef2ec1c (Update)
    [SerializeField] private float jumpSpeed = 8f;
    [SerializeField] private float gravity = 20f;
    [SerializeField] private float lowJumpMultiplier = 1.2f;

<<<<<<< HEAD
    [SerializeField, Tooltip("Gravity force")]
    private float gravity = 20.0f;
    [Header("Climb Settings")] [SerializeField]
    private float climbSpeed = 2f;

    [SerializeField, Tooltip("Multiplier for low jumps")]
    private float lowJumpMultiplier = 1.2f;

    [Header("Slide Settings")]
    [SerializeField, Tooltip("Duration of the slide in seconds")]
=======
    [Header("Climb Settings")] [SerializeField]
    private float climbSpeed = 2f;

>>>>>>> parent of ef2ec1c (Update)
=======
    [Header("Movement Settings")] [SerializeField]
    private float moveSpeed = 6f;
=======
    [Header("Movement Settings")]
    [SerializeField, Tooltip("Movement speed of the character")]
    private float moveSpeed = 6.0f;
>>>>>>> parent of 42211ae (Adding Climbing 90Degrees Wall)

    [SerializeField, Tooltip("Jump height of the character")]
    private float jumpSpeed = 8.0f;

    [SerializeField, Tooltip("Gravity force")]
    private float gravity = 20.0f;

<<<<<<< HEAD
>>>>>>> parent of ef2ec1c (Update)
    [Header("Slide Settings")] [SerializeField]
=======
    [SerializeField, Tooltip("Multiplier for low jumps")]
    private float lowJumpMultiplier = 1.2f;

    [Header("Slide Settings")]
    [SerializeField, Tooltip("Duration of the slide in seconds")]
>>>>>>> parent of 42211ae (Adding Climbing 90Degrees Wall)
    private float slideDuration = 1f;

    [SerializeField, Tooltip("Multiplier for the slide speed")]
    private float slideSpeedMultiplier = 2f;

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
    [SerializeField, Tooltip("Cooldown time for the slide in seconds")]
    private float slideCooldown = 1f;
    [SerializeField] private float slideSpeedMultiplier = 2f;
    [SerializeField] private float slideCooldown = 1f;

    private bool isJumping = false;
    private float currentJumpSpeed;
    private float verticalVelocity;
=======
>>>>>>> parent of ef2ec1c (Update)
    private CharacterController controller;
    private Vector2 defaultColliderSize;
<<<<<<< HEAD
    private Vector3 slideDirection;
=======
>>>>>>> parent of ef2ec1c (Update)
=======
    private CharacterController controller;
    private Vector2 defaultColliderSize;
>>>>>>> parent of ef2ec1c (Update)
    private float verticalVelocity;
=======
    [SerializeField, Tooltip("Cooldown time for the slide in seconds")]
    private float slideCooldown = 1f;

    private bool isJumping = false;
>>>>>>> parent of 42211ae (Adding Climbing 90Degrees Wall)
    private float currentJumpSpeed;
    private float verticalVelocity;
    private CharacterController controller;

    private bool isSliding = false;
    private float slideTimer = 0f;
    private float slideCooldownTimer = 0f;
    private Vector2 defaultColliderSize;
    private Vector3 slideDirection;
    private float horizontalInput;
    private bool isFacingRight = true;

    void Start()
    {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        controller = GetComponent<CharacterController>(); 
=======
>>>>>>> parent of ef2ec1c (Update)
=======
>>>>>>> parent of ef2ec1c (Update)
        controller = GetComponent<CharacterController>();
=======
        controller = GetComponent<CharacterController>(); 
>>>>>>> parent of 42211ae (Adding Climbing 90Degrees Wall)
        defaultColliderSize = controller.bounds.size;
    }

    void Update()
    {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        if (controller.isGrounded)
=======
>>>>>>> parent of ef2ec1c (Update)
=======
>>>>>>> parent of ef2ec1c (Update)
        HandleMovement();
        HandleJumping();
        HandleSliding();
        HandleClimbing();
    }
<<<<<<< HEAD
<<<<<<< HEAD

    void HandleMovement()
    {
        if (!isSliding)
=======
        if (controller.isGrounded)
>>>>>>> parent of 42211ae (Adding Climbing 90Degrees Wall)
        {
            verticalVelocity = 0;
            if (Input.GetButtonDown("Jump"))
            {
                isJumping = true;
                currentJumpSpeed = jumpSpeed;
            }
<<<<<<< HEAD
            horizontalInput = Input.GetAxis("Horizontal");
        }
        else

        if (horizontalInput < 0 && isFacingRight)
        {
            Flip();
        }
        else if (horizontalInput > 0 && !isFacingRight)
        {
            Flip();
        }

        controller.Move(new Vector3(horizontalInput, verticalVelocity, 0) * moveSpeed * Time.deltaTime);
    }

    void HandleJumping()
    {
        if (!controller.isGrounded)
        {
            if (Input.GetButtonUp("Jump"))
            {
                if (verticalVelocity > 0)
                {
                    verticalVelocity = verticalVelocity / lowJumpMultiplier;
                    verticalVelocity /= lowJumpMultiplier;
                }
            }

            if (!isClimbing)
            {
                verticalVelocity -= gravity * Time.deltaTime;
            }

            return; // Early return
        }

        verticalVelocity = 0;

        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            currentJumpSpeed = jumpSpeed;
=======
        }
        else
        {
            if (Input.GetButtonUp("Jump"))
            {
                isJumping = false;

                if (verticalVelocity > 0)
                {
                    verticalVelocity = verticalVelocity / lowJumpMultiplier;
                }
            }
>>>>>>> parent of 42211ae (Adding Climbing 90Degrees Wall)
        }

        if (isJumping)
        {
            verticalVelocity = currentJumpSpeed;
            currentJumpSpeed -= gravity * Time.deltaTime;
<<<<<<< HEAD

=======
>>>>>>> parent of 42211ae (Adding Climbing 90Degrees Wall)
            if (currentJumpSpeed < 0)
            {
                isJumping = false;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
<<<<<<< HEAD
=======
>>>>>>> parent of ef2ec1c (Update)
=======
>>>>>>> parent of ef2ec1c (Update)
=======
>>>>>>> parent of 42211ae (Adding Climbing 90Degrees Wall)

        if (!isSliding)
        {
            horizontalInput = Input.GetAxis("Horizontal");
        }

        if (horizontalInput < 0 && isFacingRight)
        {
            Flip();
        }
        else if (horizontalInput > 0 && !isFacingRight)
        {
            Flip();
        }
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        
        controller.Move(new Vector3(horizontalInput, verticalVelocity, 0) * moveSpeed * Time.deltaTime);
    }

=======

=======

>>>>>>> parent of ef2ec1c (Update)
=======
        
>>>>>>> parent of 42211ae (Adding Climbing 90Degrees Wall)
        controller.Move(new Vector3(horizontalInput, verticalVelocity, 0) * moveSpeed * Time.deltaTime);

<<<<<<< HEAD
    void HandleJumping()
    {
        if (!controller.isGrounded)
        {
            if (Input.GetButtonUp("Jump"))
            {
                isJumping = false;

                if (verticalVelocity > 0)
                {
                    verticalVelocity /= lowJumpMultiplier;
                }
            }

            if (!isClimbing)
            {
                verticalVelocity -= gravity * Time.deltaTime;
            }

            return; // Early return
        }

        verticalVelocity = 0;

        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            currentJumpSpeed = jumpSpeed;
        }

        if (isJumping)
        {
            verticalVelocity = currentJumpSpeed;
            currentJumpSpeed -= gravity * Time.deltaTime;

            if (currentJumpSpeed < 0)
            {
                isJumping = false;
            }
        }
    }

<<<<<<< HEAD
>>>>>>> parent of ef2ec1c (Update)
=======
>>>>>>> parent of ef2ec1c (Update)
    void HandleSliding()
    {
=======
>>>>>>> parent of 42211ae (Adding Climbing 90Degrees Wall)
        if (Input.GetKeyDown(KeyCode.LeftControl) && !isSliding && slideCooldownTimer <= 0f)
        {
            isSliding = true;
            controller.center = new Vector3(controller.center.x, controller.center.y / 2f, 0);
            slideDirection = transform.forward;
        }
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        
=======
>>>>>>> parent of ef2ec1c (Update)
=======
>>>>>>> parent of ef2ec1c (Update)

=======
        
>>>>>>> parent of 42211ae (Adding Climbing 90Degrees Wall)
        if (isSliding)
        {
            slideTimer -= Time.deltaTime;

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
            float slideProgress = 1f - slideTimer / slideDuration;
            float slideSpeed = Mathf.Lerp(slideSpeedMultiplier, 0f, slideProgress); 
            controller.Move(slideDirection * slideSpeed * Time.deltaTime); 
=======
>>>>>>> parent of ef2ec1c (Update)
=======
>>>>>>> parent of ef2ec1c (Update)
            var slideProgress = 1f - slideTimer / slideDuration;
            var slideSpeed = Mathf.Lerp(slideSpeedMultiplier, 0f, slideProgress);
            controller.Move(slideDirection * slideSpeed * Time.deltaTime);
=======
            float slideProgress = 1f - slideTimer / slideDuration;
            float slideSpeed = Mathf.Lerp(slideSpeedMultiplier, 0f, slideProgress); 
            controller.Move(slideDirection * slideSpeed * Time.deltaTime); 
>>>>>>> parent of 42211ae (Adding Climbing 90Degrees Wall)

            if (slideTimer <= 0f)
            {
                isSliding = false;
                slideCooldownTimer = slideCooldown;
                controller.height *= 2f;
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
                controller.center = new Vector3(controller.center.x, controller.center.y * 2f,0);
=======
>>>>>>> parent of ef2ec1c (Update)
=======
>>>>>>> parent of ef2ec1c (Update)
                controller.center = new Vector3(controller.center.x, controller.center.y * 2f, 0);
=======
                controller.center = new Vector3(controller.center.x, controller.center.y * 2f,0);
>>>>>>> parent of 42211ae (Adding Climbing 90Degrees Wall)
            }
        }
        slideCooldownTimer -= Time.deltaTime;
        }
    }

    void HandleClimbing()
    {
        if ((controller.collisionFlags & CollisionFlags.CollidedSides) != 0)
        {
            if (Input.GetKey(KeyCode.A))
            {
                isClimbing = true;
                controller.Move(new Vector3(-1f, climbSpeed, 0f) * moveSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                isClimbing = true;
                controller.Move(new Vector3(1f, climbSpeed, 0f) * moveSpeed * Time.deltaTime);
            }
        }
        else
        {
            isClimbing = false;
        }
    }

    void HandleClimbing()
    {
        if ((controller.collisionFlags & CollisionFlags.CollidedSides) != 0)
        {
            if (Input.GetKey(KeyCode.A))
            {
                isClimbing = true;
                controller.Move(new Vector3(-1f, climbSpeed, 0f) * moveSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                isClimbing = true;
                controller.Move(new Vector3(1f, climbSpeed, 0f) * moveSpeed * Time.deltaTime);
            }
        }
        else
        {
            isClimbing = false;
        }
    }
    
    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
