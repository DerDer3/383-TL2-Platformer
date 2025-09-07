using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D RigidBody;
    CapsuleCollider2D GroundCollider;

    InputAction MoveRight;
    InputAction MoveLeft;
    InputAction Jump;

    [SerializeField] private Animator _animator; 

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

        _animator = GetComponent<Animator>();
        Assert.NotNull(_animator);

        //Something with sound here

    }


    // Update is called once per frame
    void Update()
    {
        GetInput();
        // Moved "OnGround collision to "update" so that it updates every frame for animation purposes.
        OnGround = GroundCollider.IsTouchingLayers(LayerMask.GetMask("Environment"));

        _animator.SetBool("isWalking", XVelocity != 0 && OnGround);
        _animator.SetBool("isJumping", !OnGround);

        if (XVelocity > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (XVelocity < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    void FixedUpdate()
    {
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
