using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D RigidBody;
    CapsuleCollider2D GroundCollider;

    InputAction MoveRight;
    InputAction MoveLeft;
    InputAction Jump;

    float XVelocity = 0;
    float YVelocity = 0;
    float Speed = 200;
    float JumpSpeed = 500;

    bool OnGround = false;

    bool JumpTriggered = false;

    void Awake()
    {
        MoveRight = InputSystem.actions.FindAction("MoveRight");
        MoveLeft = InputSystem.actions.FindAction("MoveLeft");
        Jump = InputSystem.actions.FindAction("Jump");

        RigidBody = GetComponent<Rigidbody2D>();
        Assert.NotNull(RigidBody);

        GroundCollider = GetComponent<CapsuleCollider2D>();
        Assert.NotNull(GroundCollider);

        //Something with sound here

    }


    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    void FixedUpdate()
    {
        // Ground Collision
        if (GroundCollider.IsTouchingLayers(LayerMask.GetMask("Environment")))
        {
            OnGround = true;
        }
        else
        {
            OnGround = false;
        }
        // Ground Collision
        PlayerMovement();
    }

    private void GetInput()
    {
        XVelocity = 0;
        if (MoveRight.IsPressed())
        {
            XVelocity = Speed;
        }
        if (MoveLeft.IsPressed())
        {
            XVelocity = -Speed;
        }
        if (Jump.triggered && OnGround)
        {
            JumpTriggered = true;
        }
    }

    private void PlayerMovement()
    {
        if (JumpTriggered)
        {
            RigidBody.linearVelocityY = JumpSpeed * Time.fixedDeltaTime;
            JumpTriggered = false;
        }
        RigidBody.linearVelocityX = XVelocity * Time.fixedDeltaTime;

        Vector2 newVelocity = new Vector2(0, YVelocity);

        RigidBody.AddForce(newVelocity);
    }
}
