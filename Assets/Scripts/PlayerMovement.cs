using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")] [SerializeField]
    private float moveSpeed = 6f;

    [SerializeField] private float jumpSpeed = 8f;
    [SerializeField] private float gravity = 20f;
    [SerializeField] private float lowJumpMultiplier = 1.2f;

    [Header("Climb Settings")] [SerializeField]
    private float climbSpeed = 2f;

    [Header("Slide Settings")] [SerializeField]
    private float slideDuration = 1f;

    [SerializeField] private float slideSpeedMultiplier = 2f;
    [SerializeField] private float slideCooldown = 1f;

    private CharacterController controller;
    private Vector2 defaultColliderSize;
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
        controller = GetComponent<CharacterController>();
        defaultColliderSize = controller.bounds.size;
    }

    void Update()
    {
        HandleMovement();
        HandleJumping();
        HandleSliding();
        HandleClimbing();
    }

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

    void HandleSliding()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && !isSliding && slideCooldownTimer <= 0f)
        {
            isSliding = true;
            slideTimer = slideDuration;
            controller.height /= 2f;
            controller.center = new Vector3(controller.center.x, controller.center.y / 2f, 0);
            slideDirection = transform.forward;
        }

        if (isSliding)
        {
            slideTimer -= Time.deltaTime;

            var slideProgress = 1f - slideTimer / slideDuration;
            var slideSpeed = Mathf.Lerp(slideSpeedMultiplier, 0f, slideProgress);
            controller.Move(slideDirection * slideSpeed * Time.deltaTime);

            if (slideTimer <= 0f)
            {
                isSliding = false;
                slideCooldownTimer = slideCooldown;
                controller.height *= 2f;
                controller.center = new Vector3(controller.center.x, controller.center.y * 2f, 0);
            }
        }

        if (slideCooldownTimer > 0f)
        {
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
    
    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}