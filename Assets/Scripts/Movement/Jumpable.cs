using UnityEngine;
using System.Collections;
using Helpers;
using Scripts.Importer.Parts;
using Constants;

[RequireComponent(typeof(Rigidbody2D))]
public partial class Jumpable : MonoBehaviour
{
    [SerializeField]
    public JumpPart jumpData;

    [SerializeField]
    public Collider2D JumpCollider;

    [SerializeField]
    public float LongJumpTime = 0.03f;

    private bool isJumping = false;

    private float jumpAirTime = 0;

    public int JumpCount;

    private Rigidbody2D rb2d;

    private float defaultGravityScale = DefaultValues.GravityScale;

    void Start()
    {
        ResetAirTimeCounter();
        ResetJumpCount();
    }

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        JumpCheck();

        if (IsFalling() && Mathf.Approximately(rb2d.gravityScale, this.defaultGravityScale))
        {
            Debug.Log("Is Falling");
            ApplyFallingGravityMultiplier();
        }
        else if (!IsFalling())
        {
            ResetGravityScale();
        }
    }



    void ApplyFallingGravityMultiplier()
    {
        this.rb2d.gravityScale = jumpData.FallingGravityScale;
        Debug.Log($"Gravity Scale = {this.rb2d.gravityScale.ToString()}");
    }

    public void JumpCheck()
    {
        //Debug.Log($"JumpCount:{JumpCount} < jumpData.MaxJumpCount:{jumpData.MaxJumpCount}");
        if (ShouldJump())
        {
            Jump(jumpData.JumpForce);
        }
        else
        {
            IsOnTheGround();
        }
    }

    public bool IsOnTheGround()
    {
        var isGrounded = PhysicsHelpers.LayerCollisionCheck(JumpCollider, jumpData.GroundLayer) && Mathf.Approximately(rb2d.velocity.y, 0);
        if (isGrounded)
        {
            OnGrounded();
        }

        return isGrounded;
    }

    void OnGrounded()
    {
        isJumping = false;
        ResetAirTimeCounter();
        ResetJumpCount();
    }

    void OnJumpInitated()
    {
        //Debug.Log($"In OnJumpInitated Beginning JumpCount = {JumpCount}");
        JumpCount++;
        isJumping = true;
        //Debug.Log($"In OnJumpInitated Ending JumpCount = {JumpCount}");
    }

    public void Jump(float jumpForce, JumpSize jumpSize = JumpSize.Medium)
    {
        var force = GetJumpForce(jumpForce, jumpSize);
        Debug.Log($"{force.ToString()} : Jump Force");
        rb2d.AddForce(force);
        OnJumpInitated();
    }

    IEnumerator JumpRoutine()
    {
        rb2d.velocity = Vector2.zero;
        float timer = 0;

        while (IsJumpButtonPressed() && timer < jumpData.MaxJumpAirTime)
        {
            //Calculate how far through the jump we are as a percentage
            //apply the full jump force on the first frame, then apply less force
            //each consecutive frame

            float proportionCompleted = timer / jumpAirTime;

            var force = GetJumpForce(this.jumpData.JumpForce);
            Vector2 thisFrameJumpVector = Vector2.Lerp(force, Vector2.zero, proportionCompleted);
            rb2d.AddForce(thisFrameJumpVector);
            timer += Time.deltaTime;
            yield return null;
        }

        isJumping = false;
    }

    void ResetAirTimeCounter() => jumpAirTime = jumpData.MaxJumpAirTime;
    void ResetJumpCount() => JumpCount = 0;
    void ResetGravityScale() => this.rb2d.gravityScale = defaultGravityScale;

    public bool IsJumping() => isJumping;
    bool IsFalling() => rb2d.velocity.y < 0 && !IsOnTheGround();
    bool IsJumpButtonPressed() => Input.GetButtonDown(jumpData.JumpButtonName);


    bool ShouldJump() => IsJumpButtonPressed() && JumpCount < jumpData.MaxJumpCount;
    bool ShouldExtendJump() => Input.GetButton(jumpData.JumpButtonName) && isJumping && jumpAirTime > 0;
    Vector2 GetJumpForce(float baseJumpForce, JumpSize size = JumpSize.Medium) => new Vector2(0f, baseJumpForce * (float)size);


}
