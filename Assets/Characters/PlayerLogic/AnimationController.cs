using UnityEngine;
public class AnimationController
{
    private const string IS_MOVING_PARAMETER = "isMoving";

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    public AnimationController(Animator animator, SpriteRenderer spriteRenderer)
    {
        this.animator = animator;
        this.spriteRenderer = spriteRenderer;
    }

    public void SetMoving(bool isMoving)
    {
        animator.SetBool(IS_MOVING_PARAMETER, isMoving);
    }

    public void FlipSpriteWithDirection(Vector2 direction)
    {
        spriteRenderer.flipX = direction.x < 0;
    }

}
