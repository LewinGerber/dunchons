using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float collisionOffset = 0.02f;
    public ContactFilter2D movementFilter;

    Vector2 moveInput;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    Animator animator;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (moveInput != Vector2.zero)
        {
            bool canMoveInBothDirections = TryMove(moveInput);
            bool canMoveInXDirection = false;
            bool canMoveInYDirection = false;

            if (!canMoveInBothDirections && moveInput.x > 0) {
                canMoveInXDirection = TryMove(new Vector2(moveInput.x, 0));
            }

            if (!canMoveInXDirection && moveInput.y > 0) {
                canMoveInYDirection = TryMove(new Vector2(0, moveInput.y));
            }

            animator.SetBool("isMoving", canMoveInBothDirections || canMoveInXDirection || canMoveInYDirection);
        } else {
            animator.SetBool("isMoving", false);
        }

        if (moveInput.x > 0) {
            spriteRenderer.flipX = false;
        } else if (moveInput.x < 0) {
            spriteRenderer.flipX = true;
        }
    }

    private bool TryMove(Vector2 direction)
    {
        int numberOfCollisions = rb.Cast(
                direction,
                movementFilter,
                castCollisions,
                moveSpeed * Time.fixedDeltaTime + collisionOffset
            );

            if (numberOfCollisions == 0)
            {
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
                return true;
            }
            return false;
    }

    void OnMove(InputValue input)
    {
        moveInput = input.Get<Vector2>();
    }
}
