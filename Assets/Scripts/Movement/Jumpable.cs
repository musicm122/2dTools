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

    public bool isJumping = false;

    public float MaxJumpAirTime = 3f;
    public int MaxJumpCount = 2;

    public float jumpAirTime = 0;
    public int JumpCount = 0;

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
        if (ShouldJump())
        {
            StartCoroutine(JumpRoutine());
        }
        //JumpCheck();
        //IsOnTheGround();
    }

    public void JumpCheck()
    {
        if (ShouldJump())
        {
            Jump(jumpData.JumpForce);
        }

        /*
        if (ShouldExtendJump())
        {
            Debug.Log("Extending Jump!");
            Jump(jumpData.JumpForce);
            jumpAirTimeCounter -= Time.deltaTime;
        }
        */
    }

    void ResetAirTimeCounter()
    {
        jumpAirTime = MaxJumpAirTime;
    }

    void ResetJumpCount()
    {
        JumpCount = 0;
    }

    bool IsJumpButtonPressed() => Input.GetButtonDown(jumpData.JumpButtonName);
    bool ShouldJump() => IsJumpButtonPressed() && JumpCount < MaxJumpCount;
    bool ShouldExtendJump() => Input.GetButton(jumpData.JumpButtonName) && isJumping && jumpAirTime > 0;


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

    Vector2 GetJumpForce(float baseJumpForce, JumpSize size = JumpSize.Medium)
    {
        var multiplier = (float)size;
        return new Vector2(0f, baseJumpForce * multiplier);
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

        while (IsJumpButtonPressed() && timer < MaxJumpAirTime)
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

}
