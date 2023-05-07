<<<<<<< HEAD
=======
using System.Collections;
>>>>>>> parent of ef2ec1c (Update)
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
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
    [Header("Slide Settings")] [SerializeField]
    private float slideDuration = 1f;

    [SerializeField] private float slideSpeedMultiplier = 2f;
    [SerializeField] private float slideCooldown = 1f;

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
    private float verticalVelocity;
    private float currentJumpSpeed;
    private float slideTimer;
    private float slideCooldownTimer;
    private float horizontalInput;
    private Vector3 slideDirection;
    private bool isJumping;
    private bool isSliding;
    private bool isFacingRight = true;
    private bool isClimbing;

    void Start()
    {
<<<<<<< HEAD
        controller = GetComponent<CharacterController>(); 
=======
>>>>>>> parent of ef2ec1c (Update)
        controller = GetComponent<CharacterController>();
        defaultColliderSize = controller.bounds.size;
    }

    void Update()
    {
<<<<<<< HEAD
        if (controller.isGrounded)
=======
>>>>>>> parent of ef2ec1c (Update)
        HandleMovement();
        HandleJumping();
        HandleSliding();
        HandleClimbing();
    }
<<<<<<< HEAD

    void HandleMovement()
    {
        if (!isSliding)
        {
            verticalVelocity = 0;
            if (Input.GetButtonDown("Jump"))
            {
                isJumping = true;
                currentJumpSpeed = jumpSpeed;
            }
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
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
=======
>>>>>>> parent of ef2ec1c (Update)

    void HandleMovement()
    {
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
        
        controller.Move(new Vector3(horizontalInput, verticalVelocity, 0) * moveSpeed * Time.deltaTime);
    }

=======

        controller.Move(new Vector3(horizontalInput, verticalVelocity, 0) * moveSpeed * Time.deltaTime);
    }

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

>>>>>>> parent of ef2ec1c (Update)
    void HandleSliding()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && !isSliding && slideCooldownTimer <= 0f)
        {
            isSliding = true;
            controller.center = new Vector3(controller.center.x, controller.center.y / 2f, 0);
            slideDirection = transform.forward;
        }
<<<<<<< HEAD
        
=======
>>>>>>> parent of ef2ec1c (Update)

        if (isSliding)
        {
            slideTimer -= Time.deltaTime;

<<<<<<< HEAD
            float slideProgress = 1f - slideTimer / slideDuration;
            float slideSpeed = Mathf.Lerp(slideSpeedMultiplier, 0f, slideProgress); 
            controller.Move(slideDirection * slideSpeed * Time.deltaTime); 
=======
>>>>>>> parent of ef2ec1c (Update)
            var slideProgress = 1f - slideTimer / slideDuration;
            var slideSpeed = Mathf.Lerp(slideSpeedMultiplier, 0f, slideProgress);
            controller.Move(slideDirection * slideSpeed * Time.deltaTime);

            if (slideTimer <= 0f)
            {
                isSliding = false;
                slideCooldownTimer = slideCooldown;
                controller.height *= 2f;
<<<<<<< HEAD
                controller.center = new Vector3(controller.center.x, controller.center.y * 2f,0);
=======
>>>>>>> parent of ef2ec1c (Update)
                controller.center = new Vector3(controller.center.x, controller.center.y * 2f, 0);
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