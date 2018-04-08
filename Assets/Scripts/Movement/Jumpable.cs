using UnityEngine;
using System.Collections;
using Helpers;
using Scripts.Importer.Parts;

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

    private int JumpCount = 0;

    private Rigidbody2D rb2d;

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
        IsOnTheGround();
    }

    public void JumpCheck()
    {
        if (ShouldJump())
        {
            Jump(jumpData.JumpForce);
        }
    }

    void ResetAirTimeCounter()
    {
        jumpAirTime = jumpData.MaxJumpAirTime;
    }

    void ResetJumpCount()
    {
        JumpCount = 0;
    }


    public bool IsOnTheGround()
    {
        var isGrounded = PhysicsHelpers.LayerCollisionCheck(JumpCollider, jumpData.GroundLayer);
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
        isJumping = true;
        JumpCount++;
    }

    public void Jump(float jumpForce, JumpSize jumpSize = JumpSize.Medium)
    {
        OnJumpInitated();
        var force = GetJumpForce(jumpForce, jumpSize);
        Debug.Log($"{force.ToString()} : Jump Force");
        rb2d.AddForce(force);
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

    bool IsJumpButtonPressed() => Input.GetButtonDown(jumpData.JumpButtonName);
    bool ShouldJump() => IsJumpButtonPressed() && JumpCount < jumpData.MaxJumpCount;
    bool ShouldExtendJump() => Input.GetButton(jumpData.JumpButtonName) && isJumping && jumpAirTime > 0;
    Vector2 GetJumpForce(float baseJumpForce, JumpSize size = JumpSize.Medium) => new Vector2(0f, baseJumpForce * (float)size);
    public bool IsJumping() => isJumping;

}
