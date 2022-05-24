using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 1f;
    //public float collisionOffset = 0.02f;
    public ContactFilter2D movementFilter;

    Vector2 userInput;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    Animator animator;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    private AnimationController animationController;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animationController = new AnimationController(animator, this.gameObject.transform);
    }

    void OnMove(InputValue input)
    {
        userInput = input.Get<Vector2>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        bool hasUserInput = userInput != Vector2.zero;

        if (hasUserInput)
        {
            bool canMoveInBothDirections = !HasCollisionInDirection(userInput);
            bool canMoveInXDirection = !HasCollisionInDirection(new Vector2(userInput.x, 0));
            bool canMoveInYDirection = !HasCollisionInDirection(new Vector2(0, userInput.y));
            
            if (canMoveInBothDirections)
            {
                MoveInDirection(userInput);
            }

            if (!canMoveInBothDirections && canMoveInXDirection)
            {
                MoveInDirection(new Vector2(userInput.x, 0));
            }

            if (!canMoveInBothDirections && canMoveInYDirection)
            {
                MoveInDirection(new Vector2(0, userInput.y));
            }

            animationController.SetMoving(canMoveInBothDirections || canMoveInXDirection || canMoveInYDirection);
            animationController.FlipSpriteWithDirection(userInput);
        }
        else
        {
            animationController.SetMoving(false);
        }
    }

    private bool HasCollisionInDirection(Vector2 direction)
    {
        return rb.Cast(
                direction,
                movementFilter,
                castCollisions,
                moveSpeed * Time.fixedDeltaTime
            ) > 0;
    }

    private void MoveInDirection(Vector2 direction)
    {
        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
    }
}
