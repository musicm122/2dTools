using System.Collections;
using System.Collections.Generic;
using Enums;
using Scripts.Importer.Parts;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movable : MonoBehaviour, IMovable
{
    const int StillPosition = 0;

    public bool IsFacingRight;

    private Rigidbody2D rb2d;

    [SerializeField]
    public RunPart RunData;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void Move(float horizontalInputVal)
    {
        if (RunData.HasMomentum)
        {
            ApplyAcceleration(horizontalInputVal);
        }
        else
        {
            ApplyStaticSpeed(horizontalInputVal);
        }

        if (Mathf.Abs(rb2d.velocity.x) > RunData.MaxSpeed)
        {
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * RunData.MaxSpeed, rb2d.velocity.y);
        }

    }

    void ApplyAcceleration(float horizontalInputVal)
    {
        if (horizontalInputVal * rb2d.velocity.x < RunData.MaxSpeed)
        {
            rb2d.AddForce(Vector2.right * horizontalInputVal * RunData.MoveForce);
        }
    }

    void ApplyStaticSpeed(float horizontalInputVal)
    {
        if (horizontalInputVal * rb2d.velocity.x < RunData.MaxSpeed)
        {
            rb2d.velocity = Vector2.right * horizontalInputVal * RunData.MoveForce;
        }
    }

    void FixedUpdate()
    {
        if (ShouldMove())
        {
            StartCoroutine(MoveRoutine());
        }
    }

    void FlipCheck(float horizontalInputVal)
    {
        if (horizontalInputVal > 0 && !IsFacingRight)
        {
            Flip();
        }
        else if (horizontalInputVal < 0 && IsFacingRight)
        {
            Flip();
        }
    }

    bool ShouldMove() => !Mathf.Approximately(Input.GetAxis("Horizontal"), 0f);

    void Flip()
    {
        IsFacingRight = !IsFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    IEnumerator MoveRoutine()
    {
        rb2d.velocity = Vector2.zero;

        while (ShouldMove())
        {
            float h = Input.GetAxis("Horizontal");
            Move(h);
            FlipCheck(h);
            yield return null;
        }


    }
}
