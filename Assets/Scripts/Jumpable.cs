using UnityEngine;
using System.Collections;
using Helpers;

public class Jumpable : MonoBehaviour
{
    public enum JumpSize
    {
        Short,
        Medium,
        Long
    }

    public bool isJumping = false;

    [SerializeField]
    float JumpForce = 50.0f;

    [SerializeField]
    Collider2D JumpCollider;

    [SerializeField]
    string GroundLayer = "Ground";

    [SerializeField]
    string jumpButtonName = "Jump";

    public float jumpHoldTime = 0;

    public int HoldCount = 0;

    [SerializeField]
    float LongJumpTime = 0.03f;

    public void JumpCheck()
    {
        if (IsOnTheGround())
        {
            if (Input.GetButtonDown(jumpButtonName) && !isJumping)
            {
                isJumping = true;
                var jumpSize = GetJumpSize();
                Jump(this.transform, JumpForce, jumpSize);
            }
        }
    }

    public bool IsOnTheGround()
    {
        var isGrounded = PhysicsHelpers.LayerCollisionCheck(JumpCollider, GroundLayer);
        if (isGrounded)
        {
            isJumping = false;
        }
        return isGrounded;
    }


    JumpSize GetJumpSize()
    {
        //Debug.Log("GetJumpSize():  jumpHoldTime:" + jumpHoldTime.ToString());

        if (jumpHoldTime >= LongJumpTime)
        {
            //Debug.Log("Long Jump :" + jumpHoldTime.ToString());
            return JumpSize.Long;
        }
        else if (jumpHoldTime >= (LongJumpTime / 2f))
        {
            //Debug.Log("Medium Jump :" + jumpHoldTime.ToString());
            return JumpSize.Medium;
        }
        else
        {
            //Debug.Log("Short Jump :" + jumpHoldTime.ToString());
            return JumpSize.Short;
        }
    }

    IEnumerator HoldTime(string buttonName)
    {
        jumpHoldTime += Time.deltaTime;
        HoldCount++;
        yield return 0;
    }

    void UpdateHoldTime()
    {
        if (Input.GetButton(jumpButtonName))
        {
            jumpHoldTime += Time.deltaTime;
            StartCoroutine(HoldTime(jumpButtonName));
        }

        if (Input.GetButtonUp(jumpButtonName))
        {
            //StopCoroutine(HoldTime(jumpButtonName));
            jumpHoldTime = 0f;
            HoldCount = 0;
        }

    }

    public void Jump(Transform body, float jumpForce, JumpSize jumpSize)
    {
        Debug.Log(HoldCount.ToString() + " = HoldCount ");
        /*
        if (Input.GetButton(jumpButtonName) && this.jumpHoldTime > this.LongJumpTime)
        {
            Debug.Log(jumpHoldTime.ToString() + " Big Jump()");
            body.Translate(Vector2.up * (JumpForce * 2) * Time.fixedDeltaTime);
        }
        else
        {
            Debug.Log(jumpHoldTime.ToString() + " Little Jump()");
            body.Translate(Vector2.up * JumpForce * Time.fixedDeltaTime);
        }
        */
        switch (jumpSize)
        {
            case JumpSize.Long:
                Debug.Log(jumpHoldTime.ToString() + " Long");
                body.Translate(Vector2.up * (JumpForce * 2) * Time.fixedDeltaTime);
                break;
            case JumpSize.Medium:
                Debug.Log(jumpHoldTime.ToString() + " Medium");
                body.Translate(Vector2.up * jumpForce * Time.fixedDeltaTime);
                break;
            case JumpSize.Short:
                Debug.Log(jumpHoldTime.ToString() + " Short");
                body.Translate(Vector2.up * (jumpForce / 2) * Time.fixedDeltaTime);
                break;
        }

    }

    void FixedUpdate()
    {
        UpdateHoldTime();
        JumpCheck();
    }
}
